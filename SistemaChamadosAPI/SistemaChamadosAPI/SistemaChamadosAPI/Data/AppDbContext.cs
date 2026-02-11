using Microsoft.EntityFrameworkCore;
using Empresa.Models; // <-- 1. Adicionado para enxergar a classe 'Login'
using SistemaChamadosAPI.Models; // <-- 2. Adicionado para enxergar a classe 'Ticket'

namespace SistemaChamadosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // 3. Agora o C# consegue encontrar 'Login' e 'Ticket'
        public DbSet<Login> Logins { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; } // Assumindo que você chamou de 'Tickets'
      
    }
}

