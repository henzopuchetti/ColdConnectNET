using Microsoft.EntityFrameworkCore;
using ColdConnectNET.API.Models;

namespace ColdConnectNET.API.Data
{
    public class ColdContext : DbContext
    {
        public ColdContext(DbContextOptions<ColdContext> options) : base(options) { }

        public DbSet<Abrigo> Abrigos => Set<Abrigo>();
        public DbSet<Ocorrencia> Ocorrencias => Set<Ocorrencia>();
    }
}
