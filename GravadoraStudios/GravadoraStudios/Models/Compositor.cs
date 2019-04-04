using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravadoraStudios.Models
{
    public class Compositor
    {
        public int CompositorId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public virtual ICollection <Letra> Letra { get; set; }
        public int ? ResponsavelId { get; set; }
        public virtual Responsavel Reponsavel { get; set; }
    }
}