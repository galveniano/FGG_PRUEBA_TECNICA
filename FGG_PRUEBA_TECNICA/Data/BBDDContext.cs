using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FGG_PRUEBA_TECNICA.Models;

namespace FGG_PRUEBA_TECNICA.Data
{
    public class BBDDContext : DbContext
    {
        public BBDDContext (DbContextOptions<BBDDContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>().HasOne(x => x.Clientes).WithMany(x => x.Usuarios).HasForeignKey(x => x.Clientes_idClientes).OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<FGG_PRUEBA_TECNICA.Models.Clientes> Clientes { get; set; }

        public DbSet<FGG_PRUEBA_TECNICA.Models.Usuarios> Usuarios { get; set; }
    }
}
