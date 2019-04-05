using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoVendasMovel.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public bool Status_Disponibilidade_Funcionario { get; set; }

        [ForeignKey("Movel")]
        public int PK_Movel { get; set; }
        public Movel Movel { get; set; }
        public virtual ICollection<Movel> Moveis { get; set; }

        public  void Mudar_Status_Movel()
        {
            if (Movel.Status == Status.Solicitado){
                Movel.Status = Status.Em_Construcao;
                Status_Disponibilidade_Funcionario = true;
            }
        }
        public void Mudar_Status_Funcionario_Movel()
        {
            if (Status_Disponibilidade_Funcionario == false)
            {
                Movel.Status = Status.Entregue;
            }
        }
    }
}