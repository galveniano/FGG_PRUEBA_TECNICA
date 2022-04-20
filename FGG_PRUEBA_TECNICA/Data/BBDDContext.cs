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

        public DbSet<FGG_PRUEBA_TECNICA.Models.Clientes> Clientes { get; set; }
    }
}
