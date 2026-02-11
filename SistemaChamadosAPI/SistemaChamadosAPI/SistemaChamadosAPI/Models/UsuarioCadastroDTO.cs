namespace SistemaChamadosAPI.Models
{
    public class UsuarioCadastroDTO
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; } // Recebe "1" ou "2" como string
    }
}