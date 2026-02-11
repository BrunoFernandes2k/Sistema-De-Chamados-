using Microsoft.AspNetCore.Mvc;
using SistemaChamadosAPI.Data;
using SistemaChamadosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace SistemaChamadosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<LoginController> _logger;

        public LoginController(AppDbContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: api/login/cadastrar
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioCadastroDTO dados)
        {
            try
            {
                if (string.IsNullOrEmpty(dados.Email) || string.IsNullOrEmpty(dados.Senha))
                {
                    return BadRequest("Email e Senha são obrigatórios.");
                }

                if (await _context.Logins.AnyAsync(l => l.Email == dados.Email))
                {
                    _logger.LogWarning("Falha no cadastro: E-mail {Email} já existe.", dados.Email);
                    return BadRequest("Já existe um usuário com esse e-mail.");
                }

                int tipoUsuarioInt = 2;
                if (!string.IsNullOrEmpty(dados.TipoUsuario))
                {
                    if (int.TryParse(dados.TipoUsuario, out int numero))
                    {
                        tipoUsuarioInt = numero;
                    }
                    else if (dados.TipoUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                    {
                        tipoUsuarioInt = 1;
                    }
                }

                // 🔧 CORREÇÃO: Usando os nomes CORRETOS das colunas do banco
                // A tabela tem: Nome, Usuario, Email, Senha, TipoUsuario
                var primeiroLogin = await _context.Logins.FirstOrDefaultAsync();
                if (primeiroLogin != null)
                {
                    var tipo = primeiroLogin.GetType();
                    var novoLogin = Activator.CreateInstance(tipo);

                    // Usa os nomes das propriedades que EXISTEM no model
                    tipo.GetProperty("Nome")?.SetValue(novoLogin, dados.NomeCompleto);
                    tipo.GetProperty("Usuario")?.SetValue(novoLogin, dados.NomeUsuario);
                    tipo.GetProperty("Email")?.SetValue(novoLogin, dados.Email);
                    tipo.GetProperty("Senha")?.SetValue(novoLogin, dados.Senha);
                    tipo.GetProperty("TipoUsuario")?.SetValue(novoLogin, tipoUsuarioInt);

                    _context.Logins.Add((dynamic)novoLogin);
                }
                else
                {
                    // Se não tem nenhum registro ainda, cria manualmente
                    // ⚠️ AJUSTE CONFORME SEU MODEL!
                    return BadRequest("Não foi possível criar o usuário. Verifique o model.");
                }

                await _context.SaveChangesAsync();

                _logger.LogInformation("Usuário {Email} cadastrado com sucesso.", dados.Email);
                return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar usuário.");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST: api/login
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] LoginRequestDTO login)
        {
            try
            {
                _logger.LogInformation("Tentativa de login: Usuario={Usuario}", login.NomeUsuario ?? "NULL");

                var usuario = await _context.Logins
                    .FirstOrDefaultAsync(l =>
                        l.Email == login.NomeUsuario ||
                        l.Usuario == login.NomeUsuario);

                if (usuario == null)
                {
                    _logger.LogWarning("Usuário não encontrado: {Usuario}", login.NomeUsuario);
                    return Unauthorized("Usuário ou senha inválidos.");
                }

                if (usuario.Senha != login.Senha)
                {
                    _logger.LogWarning("Senha incorreta para usuário: {Usuario}", login.NomeUsuario);
                    return Unauthorized("Usuário ou senha inválidos.");
                }

                _logger.LogInformation("Login bem-sucedido: {Usuario}", login.NomeUsuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao autenticar usuário.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // GET: api/login
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var todosLogins = await _context.Logins.ToListAsync();
                return Ok(todosLogins);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os logins.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}