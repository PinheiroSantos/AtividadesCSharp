using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravadoraStudios.Models
{
    public class Responsavel
    {
        public int ResponsavelId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Compositor> Compositor { get; set; }
    }
}