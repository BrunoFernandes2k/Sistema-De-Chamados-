using Empresa.Web.Ui.DTOs;
using Empresa.Web.Ui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Empresa.Web.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService = new ApiService();

        [AllowAnonymous]
        public ActionResult Index() { return View("Login"); }

        [AllowAnonymous]
        public ActionResult Login() { return View(); }

        [AllowAnonymous]
        public ActionResult Register() { return View(); }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UsuarioCadastroDTO usuario, string ConfirmarSenha)
        {
            if (usuario.Senha != ConfirmarSenha)
            {
                ViewBag.ErrorMessage = "As senhas não coincidem.";
                return View("Register");
            }

            bool sucesso = await _apiService.CadastrarUsuario(usuario);

            if (sucesso)
            {
                TempData["SuccessMessage"] = "Conta criada com sucesso! Faça login abaixo.";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao criar conta.";
                return View("Register");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string NomeUsuario, string Senha)
        {
            var dadosLogin = new LoginDTO { NomeUsuario = NomeUsuario, Senha = Senha };
            UsuarioRespostaDTO usuario = await _apiService.Login(dadosLogin);

            if (usuario != null)
            {
                string perfil = (usuario.TipoUsuario == 1) ? "Administrador" : "Colaborador";

                Session["UserProfile"] = perfil;
                Session["UserName"] = usuario.Nome;
                Session["UserId"] = usuario.Id;
                Session["IsAuthenticated"] = true;

                FormsAuthentication.SetAuthCookie(NomeUsuario, false);

                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.ErrorMessage = "Usuário ou senha inválidos. Tente novamente.";
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            TempData["SuccessMessage"] = "Você saiu do sistema com segurança.";
            return RedirectToAction("Login", "Home");
        }

        public async Task<ActionResult> Dashboard(string perfil)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login");
            }

            ViewBag.UserName = Session["UserName"];
            ViewBag.UserProfile = Session["UserProfile"];
            ViewBag.UserId = Session["UserId"];
            ViewBag.Title = "Dashboard";

            try
            {
                // Buscar estatísticas
                if (Session["UserProfile"] as string == "Administrador")
                {
                    // Estatísticas gerais para administrador
                    var stats = await _apiService.BuscarEstatisticasAsync();
                    ViewBag.Estatisticas = stats;
                }
                else
                {
                    // Estatísticas do usuário específico
                    int usuarioId = Convert.ToInt32(Session["UserId"]);
                    var stats = await _apiService.BuscarEstatisticasUsuarioAsync(usuarioId);
                    ViewBag.Estatisticas = stats;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao buscar estatísticas: {ex.Message}");
            }

            return View();
        }

        // ✅ CORRIGIDO: GET: /Home/NovoTicket
        public ActionResult NovoTicket()
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login", "Home");
            }

            // ✅ ADICIONE ESTAS LINHAS:
            ViewBag.UserProfile = Session["UserProfile"] as string;
            ViewBag.UserName = Session["UserName"] as string;
            ViewBag.Title = "Novo Ticket";

            return View();
        }

        // ✅ CORRIGIDO: POST: /Home/NovoTicket
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NovoTicket(TicketNovoDTO ticket)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login", "Home");
            }

            // ✅ ADICIONE ESTAS LINHAS:
            ViewBag.UserProfile = Session["UserProfile"] as string;
            ViewBag.UserName = Session["UserName"] as string;
            ViewBag.Title = "Novo Ticket";

            if (string.IsNullOrEmpty(ticket.Assunto) || string.IsNullOrEmpty(ticket.Descricao))
            {
                ViewBag.ErrorMessage = "Assunto e Descrição são obrigatórios.";
                return View(ticket);
            }

            ticket.UsuarioID = Session["UserId"] != null ? (int)Session["UserId"] : 0;
            ticket.NomeUsuario = Session["UserName"] as string;
            ticket.DataAbertura = DateTime.Now;
            ticket.Status = "Aberto";

            bool sucesso = await _apiService.CriarTicketAsync(ticket);

            if (sucesso)
            {
                TempData["SuccessMessage"] = "Ticket criado com sucesso!";
                return RedirectToAction("MeusTickets", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao criar ticket. Tente novamente.";
                return View(ticket);
            }
        }

        // ✅ CORRIGIDO: GET: /Home/MeusTickets
        public async Task<ActionResult> MeusTickets()
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login", "Home");
            }

            // ✅ ADICIONE ESTAS LINHAS:
            ViewBag.UserProfile = Session["UserProfile"] as string;
            ViewBag.UserName = Session["UserName"] as string;
            ViewBag.Title = "Meus Tickets";

            int usuarioId = Session["UserId"] != null ? (int)Session["UserId"] : 0;
            var tickets = await _apiService.GetMeusTicketsAsync(usuarioId);

            return View(tickets);
        }

        [HttpPost]
        public async Task<ActionResult> DeletarTicket(int id)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return Json(new { success = false, message = "Não autenticado" });
            }

            bool sucesso = await _apiService.DeletarTicketAsync(id);

            if (sucesso)
            {
                return Json(new { success = true, message = "Ticket deletado com sucesso!" });
            }
            else
            {
                return Json(new { success = false, message = "Erro ao deletar ticket." });
            }
        }

        // ✅ CORRIGIDO: Administracao
        public async Task<ActionResult> Administracao(string perfil)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login");
            }

            if (Session["UserProfile"] as string != "Administrador")
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.UserName = Session["UserName"];
            ViewBag.UserProfile = Session["UserProfile"];
            ViewBag.UserId = Session["UserId"];
            ViewBag.Title = "Administração";

            try
            {
                // Buscar estatísticas para a página de administração
                var stats = await _apiService.BuscarEstatisticasAsync();
                ViewBag.Estatisticas = stats;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao buscar estatísticas: {ex.Message}");
            }

            return View();
        }

        // ✅ CORRIGIDO: GET: /Home/TodosTickets
        public async Task<ActionResult> TodosTickets()
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Login", "Home");
            }

            if (Session["UserProfile"] as string != "Administrador")
            {
                TempData["ErrorMessage"] = "Acesso negado. Apenas administradores.";
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.UserProfile = Session["UserProfile"] as string;
            ViewBag.UserName = Session["UserName"] as string;
            ViewBag.Title = "Todos os Tickets";

            var tickets = await _apiService.GetMeusTicketsAsync();

            return View(tickets);
        }

        [HttpPost]
        public async Task<ActionResult> AtualizarStatusTicket(int id, string status)
        {
            try
            {
                if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
                {
                    return Json(new { success = false, message = "Não autenticado" }, JsonRequestBehavior.AllowGet);
                }

                if (Session["UserProfile"] as string != "Administrador")
                {
                    return Json(new { success = false, message = "Acesso negado" }, JsonRequestBehavior.AllowGet);
                }

                bool sucesso = await _apiService.AtualizarStatusTicketAsync(id, status);

                if (sucesso)
                {
                    return Json(new { success = true, message = "Status atualizado com sucesso!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar status." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: /Home/GetTicketDetalhes
        [HttpGet]
        public async Task<JsonResult> GetTicketDetalhes(int id)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return Json(new { success = false, message = "Não autenticado" }, JsonRequestBehavior.AllowGet);
            }

            if (Session["UserProfile"] as string != "Administrador")
            {
                return Json(new { success = false, message = "Acesso negado" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                System.Diagnostics.Debug.WriteLine($"🔍 Buscando ticket ID: {id}");

                // Busca todos os tickets usando o método que já funciona
                var tickets = await _apiService.GetMeusTicketsAsync();

                System.Diagnostics.Debug.WriteLine($"📦 Total de tickets retornados: {tickets?.Count ?? 0}");

                // Encontra o ticket específico
                var ticket = tickets?.FirstOrDefault(t => t.Id == id);

                if (ticket != null)
                {
                    System.Diagnostics.Debug.WriteLine($"✅ Ticket encontrado: ID={ticket.Id}, Assunto={ticket.Assunto}");

                    // Retorna o ticket com todos os dados
                    var resultado = new
                    {
                        id = ticket.Id,
                        usuarioId = ticket.UsuarioId,
                        assunto = ticket.Assunto,
                        descricao = ticket.Descricao ?? "Sem descrição",
                        status = ticket.Status,
                        prioridade = ticket.Prioridade,
                        dataAbertura = ticket.DataAbertura,
                        dataFechamento = ticket.DataFechamento,
                        nomeUsuario = ticket.NomeUsuario
                    };

                    System.Diagnostics.Debug.WriteLine($"📤 Retornando: {resultado.assunto}");

                    return Json(resultado, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Ticket ID {id} não encontrado na lista");
                    return Json(new { success = false, message = "Ticket não encontrado" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERRO: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"❌ Stack: {ex.StackTrace}");
                return Json(new { success = false, message = $"Erro: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    
}