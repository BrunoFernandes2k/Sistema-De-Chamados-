using Newtonsoft.Json; // <-- ADICIONE ISTO
namespace Empresa.Web.Ui.DTOs
{
    // O objeto que será enviado no POST para a API de Cadastro
    public class UsuarioCadastroDTO
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
    }
}