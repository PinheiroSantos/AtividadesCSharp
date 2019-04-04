using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravadoraStudios.Models
{
    public class Publicacao
    {
        public int PublicacaoId { get; set; }
        public int Data { get; set; }
        public int LetraId { get; set; }
        public Letra Letra { get; set; }

        public bool VerificarPublicaco()
        {
            if(Letra.Compositor.Idade >= 18)
            {
                return true;
            }
            else if(Letra.Compositor.ResponsavelId!= null){
                return true;
            }
            return false;
        }
    }
}