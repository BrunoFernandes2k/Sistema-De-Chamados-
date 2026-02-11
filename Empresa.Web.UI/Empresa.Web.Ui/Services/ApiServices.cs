using Empresa.Web.Ui.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic; // <-- 1. ADICIONADO PARA 'List<T>'

namespace Empresa.Web.Ui.Services
{
    public class ApiService
    {
        private readonly string _baseUrl = "http://localhost:5288";
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // =================================================================
        // MÉTODO DE CADASTRO
        // =================================================================
        public async Task<bool> CadastrarUsuario(UsuarioCadastroDTO dadosCadastro)
        {
            var endpoint = _baseUrl + "/api/login/cadastrar";
            var jsonContent = JsonConvert.SerializeObject(dadosCadastro);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            return response.IsSuccessStatusCode;
        }

        // =================================================================
        // MÉTODO DE LOGIN - CORRIGIDO
        // =================================================================
        public async Task<UsuarioRespostaDTO> Login(LoginDTO dadosLogin)
        {
            try
            {
                string endpoint = _baseUrl + "/api/login";

                var jsonContent = JsonConvert.SerializeObject(dadosLogin);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                System.Diagnostics.Debug.WriteLine($"Status Code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"JSON Retornado: {jsonString}");

                    var usuarioApi = JsonConvert.DeserializeObject<UsuarioRespostaDTO>(jsonString);

                    // 2. CORREÇÃO: Retorna o objeto do usuário inteiro
                    return usuarioApi;
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Erro da API: {erro}");
                }

                return null; // Falha no login
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exceção no Login: {ex.Message}");
                return null;
            }
        }

        // =================================================================
        // SEÇÃO DE TICKETS
        // =================================================================

        /// <summary>
        /// Cria um novo ticket
        /// </summary>
        public async Task<bool> CriarTicketAsync(TicketNovoDTO novoTicket)
        {
            try
            {
                string endpoint = _baseUrl + "/api/tickets"; // ← CORRIGIDO

                var jsonContent = JsonConvert.SerializeObject(novoTicket);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Erro ao criar ticket: {response.StatusCode} - {erro}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exceção no CriarTicketAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Busca todos os tickets (ou tickets do usuário)
        /// </summary>
        public async Task<List<TicketListDTO>> GetMeusTicketsAsync(int? usuarioId = null)
        {
            try
            {
                // Se passar usuarioId, busca só do usuário, senão busca todos
                string endpoint = usuarioId.HasValue
                    ? _baseUrl + $"/api/tickets/usuario/{usuarioId.Value}"
                    : _baseUrl + "/api/tickets";

                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // ✅ DEBUG - Ver o JSON
                    System.Diagnostics.Debug.WriteLine("📦 JSON recebido da API:");
                    System.Diagnostics.Debug.WriteLine(jsonString);

                    // Deserializa para TicketDTO (da API) e converte para TicketListDTO
                    var ticketsApi = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
                    var tickets = new List<TicketListDTO>();

                    foreach (var t in ticketsApi)
                    {
                        tickets.Add(new TicketListDTO
                        {
                            Id = t.id ?? t.Id,
                            UsuarioId = t.usuarioId ?? t.UsuarioId, // ← ADICIONE ESTA LINHA
                            Assunto = t.assunto ?? t.Assunto,
                            Descricao = t.descricao ?? t.Descricao, // ← ADICIONE ESTA LINHA
                            Status = t.status ?? t.Status,
                            Prioridade = t.prioridade ?? t.Prioridade,
                            DataAbertura = t.dataAbertura ?? t.DataAbertura,
                            DataFechamento = t.dataFechamento ?? t.DataFechamento,
                            NomeUsuario = t.nomeUsuario ?? t.NomeUsuario
                        });

                        // ✅ DEBUG - Ver cada ticket mapeado
                        System.Diagnostics.Debug.WriteLine($"🎫 Ticket {tickets[tickets.Count - 1].Id}: Descrição = '{tickets[tickets.Count - 1].Descricao}'");
                    }

                    return tickets;
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Erro ao buscar tickets: {response.StatusCode} - {erro}");
                    return new List<TicketListDTO>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exceção no GetMeusTicketsAsync: {ex.Message}");
                return new List<TicketListDTO>();
            }
        }
        /// <summary>
        /// Deleta um ticket
        /// </summary>
        public async Task<bool> DeletarTicketAsync(int ticketId)
        {
            try
            {
                string endpoint = _baseUrl + $"/api/tickets/{ticketId}";
                var response = await _httpClient.DeleteAsync(endpoint);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao deletar ticket: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AtualizarStatusTicketAsync(int ticketId, string status)
        {
            try
            {
                string endpoint = _baseUrl + $"/api/tickets/{ticketId}/status";
                var jsonContent = JsonConvert.SerializeObject(status);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao atualizar status: {ex.Message}");
                return false;
            }
        }
        public async Task<dynamic> BuscarEstatisticasUsuarioAsync(int usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/tickets/estatisticas/usuario/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<dynamic>(json);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao buscar estatísticas do usuário: {ex.Message}");
                return null;
            }
        }
            public async Task<dynamic> BuscarEstatisticasAsync()
            {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/tickets/estatisticas");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<dynamic>(json);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao buscar estatísticas: {ex.Message}");
                return null;
            }
           
            }
        public async Task<dynamic> GetTicketPorIdAsync(int id)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"🌐 Chamando API: {_baseUrl}/api/tickets/{id}");

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/tickets/{id}");

                System.Diagnostics.Debug.WriteLine($"📡 Status da resposta: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    System.Diagnostics.Debug.WriteLine($"📄 JSON recebido: {json}");

                    var ticket = JsonConvert.DeserializeObject<dynamic>(json);

                    System.Diagnostics.Debug.WriteLine($"✅ Ticket deserializado com sucesso");

                    return ticket;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Erro na API: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Exceção no GetTicketPorIdAsync: {ex.Message}");
                return null;
            }
        }
    }
}
