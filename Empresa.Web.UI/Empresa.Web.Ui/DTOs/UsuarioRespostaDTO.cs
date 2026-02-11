using Newtonsoft.Json;
using System.Web.Helpers;

namespace Empresa.Web.Ui.DTOs
{
    // DTO para receber a resposta da API após login
    public class UsuarioRespostaDTO
    {
        // Mapeia o JSON que a API retorna (do seu Login.cs)

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")] // 'email' minúsculo
        public string Email { get; set; }

        [JsonProperty("tipoUsuario")]
        public int TipoUsuario { get; set; }
    }
}
