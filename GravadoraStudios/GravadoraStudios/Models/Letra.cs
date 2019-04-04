using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravadoraStudios.Models
{
    public class Letra
    {
        public int LetraId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public bool Publicada { get; set; }
        public int CompositorId { get; set; }
        public virtual Compositor Compositor { get; set; }
    }
}