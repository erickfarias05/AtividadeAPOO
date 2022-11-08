using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Modelo.Cadastros;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Exame> Exames { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Especie> Especies { get; set; }


    }
}
