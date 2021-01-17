namespace Project.Models
{
    public class Slider : Base
    {
        public int IdSlider { get; set; }
        public int Cod_Tipo { get; set; }
        public string STipo { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion { get; set; }
        public int Cod_Url { get; set; }
        public string STipo_Url { get; set; }
        public string SUrl { get; set; }
        public int Cod_Tipo_Archivo { get; set; }
        public string STipo_Archivo { get; set; }
        public int Cod_Ubicacion { get; set; }
        public string SCod_Ubicacion { get; set; }
        public string SArchivo { get; set; }
        public string BImagen { get; set; }
        public string SEstado { get; set; }
        public int IdUsuario { get; set; }
        public string UrlImagen { get; set; }

    }
    public class PublicadoSlider
    {
        public int IdSlider { get; set; }
        public string Tipo { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion { get; set; }
        public string Tipo_Url { get; set; }
        public string SUrl { get; set; }
        public string Tipo_Archivo { get; set; }
        public string Ubicacion { get; set; }
        public string SArchivo { get; set; }
        public string Url_Slider { get; set; }
    }
}
