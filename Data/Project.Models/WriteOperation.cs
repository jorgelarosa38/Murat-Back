using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class WriteOperation
    {
        public int IdOperacion { get; set; }
        public string Accion { get; set; }
        public int IdDato { get; set; }
        public List<XMLStructure> XMLDatos { get; set; }
        public string XML { get; set; }
    }

    public class WriteOutput
    {
        public int IdDato { get; set; }
        public int IdError { get; set; }
        public string DesError { get; set; }
    }
    public class XMLStructure
    {
        public string Entidad { get; set; }
        public string Etiqueta { get; set; }
        public string Valor { get; set; }
    }
}
