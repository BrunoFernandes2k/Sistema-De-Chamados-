using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaChamadosAPI.Data;
using SistemaChamadosAPI.Models;  // ← NAMESPACE CORRETO DO TICKET!

namespace SistemaChamadosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var tickets = await _context.Tickets
                .OrderByDescending(t => t.DataAbertura)
                .ToListAsync();

            return Ok(tickets);
        }

        // GET: api/tickets/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetPorUsuario(int usuarioId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.UsuarioId == usuarioId)
                .OrderByDescending(t => t.DataAbertura)
                .ToListAsync();

            return Ok(tickets);
        }

        // GET: api/tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // POST: api/tickets
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Ticket inválido");
            }

            ticket.DataAbertura = DateTime.Now;
            ticket.Status = "Aberto";

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPorId), new { id = ticket.Id }, ticket);
        }

        // PUT: api/tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest("ID não corresponde");
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var existe = await _context.Tickets.AnyAsync(e => e.Id == id);
                if (!existe)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(int id, [FromBody] string status)
        {
            try
            {
                var ticket = await _context.Tickets.FindAsync(id);

                if (ticket == null)
                {
                    return NotFound(new { mensagem = "Ticket não encontrado" });
                }

                
                status = status.Trim('"');

                ticket.Status = status;

                if (status == "Concluido")
                {
                    ticket.DataFechamento = DateTime.Now;
                }
                else if (status == "Aberto" || status == "Em Andamento")
                {
                    ticket.DataFechamento = null;
                }

                await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Status atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro: {ex.Message}" });
            }
        }
        // GET: api/tickets/estatisticas
        [HttpGet("estatisticas")]
        public async Task<IActionResult> GetEstatisticas()
        {
            try
            {
                var totalTickets = await _context.Tickets.CountAsync();
                var ticketsAbertos = await _context.Tickets.CountAsync(t => t.Status == "Aberto");
                var ticketsEmAndamento = await _context.Tickets.CountAsync(t => t.Status == "Em Andamento");
                var ticketsConcluidos = await _context.Tickets.CountAsync(t => t.Status == "Concluido");

                // CONTA USUÁRIOS ATIVOS DA TABELA LOGINS
                // Assumindo que TipoUsuario 1 = Admin, 2 = Colaborador (ambos ativos)
                var usuariosAtivos = await _context.Logins.CountAsync();

                return Ok(new
                {
                    total = totalTickets,
                    abertos = ticketsAbertos,
                    emAndamento = ticketsEmAndamento,
                    concluidos = ticketsConcluidos,
                    usuariosAtivos = usuariosAtivos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro ao buscar estatísticas: {ex.Message}" });
            }
        }

        // GET: api/tickets/estatisticas/usuario/{usuarioId}
        [HttpGet("estatisticas/usuario/{usuarioId}")]
        public async Task<IActionResult> GetEstatisticasUsuario(int usuarioId)
        {
            try
            {
                var totalTickets = await _context.Tickets.CountAsync(t => t.UsuarioId == usuarioId);
                var ticketsAbertos = await _context.Tickets.CountAsync(t => t.UsuarioId == usuarioId && t.Status == "Aberto");
                var ticketsEmAndamento = await _context.Tickets.CountAsync(t => t.UsuarioId == usuarioId && t.Status == "Em Andamento");
                var ticketsConcluidos = await _context.Tickets.CountAsync(t => t.UsuarioId == usuarioId && t.Status == "Concluido");

                return Ok(new
                {
                    total = totalTickets,
                    abertos = ticketsAbertos,
                    emAndamento = ticketsEmAndamento,
                    concluidos = ticketsConcluidos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro ao buscar estatísticas do usuário: {ex.Message}" });
            }
        }
       
    }
}