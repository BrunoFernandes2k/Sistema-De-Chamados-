using System.Collections.Generic;


namespace Empresa.Web.Ui.DTOs // (SEU NAMESPACE)
{
    // Modelo principal da dashboard do Admin
    public class DashboardAdminDTO
    {
        // Cards de Estatísticas
        public int TotalTickets { get; set; }
        public int TicketsEmAberto { get; set; }
        public int TicketsEmAndamento { get; set; }
        public int TicketsConcluidos { get; set; }

        // Tabela de Tickets Recentes
        public TicketListDTO MeuTicket { get; set; } // <-- Use o nome da classe, ex: TicketListDTO
    }
}