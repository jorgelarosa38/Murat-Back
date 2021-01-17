using System.Collections.Generic;
using System.Dynamic;

namespace Project.Models
{
    public class ListNroImagen
    {
        public int Nro_Imagen { get; set; }
        public List<Archivo> Archivo_Imagenes { get; set; }
    }

    public class Archivo
    {
        public string SArchivo { get; set; }
        public int NOrden { get; set; }
        public string Url_Imagen { get; set; }
    }

    public class ImagenProducto : Base
    {
        public int IdImagen { get; set; }
        public int IdProducto { get; set; }
        public int Cod_Color { get; set; }
        public string SColor { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo { get; set; }
        public string BImagen { get; set; }
        public string UrlImagen { get; set; }
        public string SEstado { get; set; }
        public int IdUsuario { get; set; }
    }
}
