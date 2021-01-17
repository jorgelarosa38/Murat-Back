namespace Project.Models
{
    public class Precio : Base
    {
        public int IdPrecio { get; set; }
        public int IdProducto { get; set; }
        public int Cod_Precio { get; set; }
        public string SCod_Precio { get; set; }
        public string SPrecio { get; set; }
        public double NImporte { get; set; }
        public double NImporte_orgi { get; set; }
        public int Cod_Envio { get; set; }
        public int Cod_Moneda { get; set; }
        public string SEstado { get; set; }
        public string DFecha_Inicio { get; set; }
        public int IdUsuario { get; set; }
    }
}
