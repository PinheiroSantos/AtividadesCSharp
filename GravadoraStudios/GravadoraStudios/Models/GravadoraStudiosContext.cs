using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GravadoraStudios.Models
{
    public class GravadoraStudiosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GravadoraStudiosContext() : base("name=GravadoraStudiosContext")
        {
        }

        public System.Data.Entity.DbSet<GravadoraStudios.Models.Responsavel> Responsavels { get; set; }

        public System.Data.Entity.DbSet<GravadoraStudios.Models.Compositor> Compositors { get; set; }

        public System.Data.Entity.DbSet<GravadoraStudios.Models.Publicacao> Publicacaos { get; set; }

        public System.Data.Entity.DbSet<GravadoraStudios.Models.Letra> Letras { get; set; }
    }
}
