namespace Project.Models
{
    public class Marca : Base
    {
        public int IdMarca { get; set; }
        public string SMarca { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo { get; set; }
        public string BImagen { get; set; }
        public int IdUsuario { get; set; }
        public string SEstado { get; set; }
        public string UrlImagen { get; set; }
    }

    public class PublicadoMarca
    {
        public int IdMarca { get; set; }
        public string SMarca { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo { get; set; }
        public string Url_Marca { get; set; }
    }
}
