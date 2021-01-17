using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Publicado
    {
        public int Cod_operacion { get; set; }
        public int IdDato { get; set; }
    }

    public class ExtPublicado
    {
        public int Cod_Operacion { get; set; }
        public string Operacion { get; set; }
        public string SDescripcion { get; set; }
        public string IdDato { get; set; }
    }
}
