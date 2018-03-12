using FanSoft.CadCli.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace FanSoft.CadCli.Core.Data.EF
{
    public class CadCliDataContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public CadCliDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CadCliConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ClienteMap());
            modelBuilder.ApplyConfiguration(new Maps.TelefoneMap());

            //desativar cascate em todas fks
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList();

            cascadeFKs.ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }

    }
}
