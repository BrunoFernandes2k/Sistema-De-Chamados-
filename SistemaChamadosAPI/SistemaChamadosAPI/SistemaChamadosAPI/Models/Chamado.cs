namespace SistemaChamadosAPI.Models
{
    public sealed class Chamado
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Setor { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Prioridade { get; set; }
        public string Status { get; set; } = "Em Aberto ";
    }
}
