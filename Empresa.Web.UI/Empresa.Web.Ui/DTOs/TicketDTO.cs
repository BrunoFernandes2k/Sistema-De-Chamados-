using System;

namespace Empresa.Web.Ui.DTOs // (SEU NAMESPACE)
{
    // Usado para listar tickets na tabela
    public class TicketNovoDTO
    {
        // O Id será gerado pelo banco
        // DataFechamento será null no início

        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }       // Ex: "Aberto"
        public string Prioridade { get; set; }   // Ex: "Média"
        public DateTime DataAbertura { get; set; }
        public int UsuarioID { get; set; }       // ID do usuário logado
        public string NomeUsuario { get; set; }  // Nome do usuário logado
    }

    public class TicketListDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; } // ← ADICIONE ESTA LINHA
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string NomeUsuario { get; set; }
    }
   
  
}