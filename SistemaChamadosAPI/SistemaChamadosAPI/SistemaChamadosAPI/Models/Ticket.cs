using System.ComponentModel.DataAnnotations;
using System;

namespace SistemaChamadosAPI.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Assunto { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // Aberto, EmAndamento, Concluido

        [Required]
        [StringLength(50)]
        public string Prioridade { get; set; } // Baixa, Media, Alta

        public DateTime DataAbertura { get; set; }

        public DateTime? DataFechamento { get; set; }

        // Relacionamento com Login (Usuario)
        public int UsuarioId { get; set; }

        [StringLength(100)]
        public string NomeUsuario { get; set; }
    }
}
