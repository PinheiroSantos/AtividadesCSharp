using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciamentoVendasMovel.Models
{
    public class GerenciamentoVendasMovelContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GerenciamentoVendasMovelContext() : base("name=GerenciamentoVendasMovelContext")
        {
        }

        public System.Data.Entity.DbSet<GerenciamentoVendasMovel.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<GerenciamentoVendasMovel.Models.Movel> Movels { get; set; }

        internal void SaveChanges(object v)
        {
            throw new NotImplementedException();
        }
    }
}
