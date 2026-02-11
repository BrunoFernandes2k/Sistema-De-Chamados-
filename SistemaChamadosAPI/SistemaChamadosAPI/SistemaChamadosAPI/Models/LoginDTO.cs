namespace SistemaChamadosAPI.Models
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
    }
}