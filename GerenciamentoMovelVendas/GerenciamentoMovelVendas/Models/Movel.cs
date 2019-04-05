using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciamentoMovelVendas.Models
{
    public enum Status { Solicitado, Em_Construcao, Entregue }
    public class Movel
    {
        public int MovelId { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public Medida Medida { get; set; }
        public string Material { get; set; }
        public string LinkImagemMovel { get; set; }
        public Status Status { get; set; }
        public virtual Funcionario Funcionario{ get; set; }


        public Movel()
        {
            Status = Status.Solicitado;
        }
    }
}