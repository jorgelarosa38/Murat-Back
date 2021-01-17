using System.Collections.Generic;

namespace Project.Models
{
    public class Producto : Base
    {
        public int IdProducto { get; set; }
        public string SCodigo { get; set; }
        public string SProducto { get; set; }
        public int Cod_Categoria { get; set; }
        public string SCategoria { get; set; }
        public int Cod_Genero { get; set; }
        public string SGenero { get; set; }
        public int IdMarca { get; set; }
        public int Cod_Grupo { get; set; }
        public int Cod_Etiqueta { get; set; }
        public int Cod_Material { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo_Talla { get; set; }
        public string BImagen_Talla { get; set; }
        public string SArchivo_Producto { get; set; }
        public string BImagen_Producto { get; set; }
        public string SEstado { get; set; }
        public int IdUsuario { get; set; }
        public string UrlImagen_Talla { get; set; }
        public string UrlImagen_Producto { get; set; }
    }

    public class PublicadoProducto
    {
        public string SCodigo { get; set; }
        public string SProducto { get; set; }
        public string Categoria { get; set; }
        public string Genero { get; set; }
        public string SMarca { get; set; }
        public string Archivo_Marca { get; set; }
        public string Url_Marca { get; set; }
        public string Grupo { get; set; }
        public string Etiqueta { get; set; }
        public string Material { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo_Producto { get; set; }
        public string Url_Producto { get; set; }
        public string SArchivo_Talla { get; set; }
        public string Url_Talla { get; set; }
        public string Tipo_Precio { get; set; }
        public string SPrecio { get; set; }
        public string NImporte_Orgi { get; set; }
        public string NImporte { get; set; }
        public string DFecha_Inicio { get; set; }
        public string Envio { get; set; }
        public string Moneda { get; set; }
        public List<PubColor> Color { get; set; }
        public List<PubImagen> Imagen { get; set; }
        public List<PubProductoImagen> Producto_Imagen { get; set; }
        public List<PubTalla> Talla { get; set; }
    }
    public class PubColor
    {
        public int IdImagen { get; set; }
        public int Cod_Color { get; set; }
        public string Color { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion_Imagen { get; set; }
        public string SArchivo_Imagen { get; set; }
        public string Url_Imagen { get; set; }
    }
    public class PubImagen
    {
        public int Cod_Color_0 { get; set; }
        public string SArchivo_Imagen_0 { get; set; }
        public string Url_Imagen_0 { get; set; }
    }
    public class PubProductoImagen
    {
        public string Color_0 { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion_Imagen_0 { get; set; }
        public string SArchivo_Imagen_0 { get; set; }
        public string Url_Imagen_0 { get; set; }
    }
    public class PubTalla
    {
        public int Cod_Talla { get; set; }
        public string Talla { get; set; }
    }
    public class PublicadoProductoServ
    {
        public int IdProducto { get; set; }
        public string SCodigo { get; set; }
        public string SProducto { get; set; }
        public string SCategoria { get; set; }
        public string Genero { get; set; }
        public string Marca { get; set; }
        public string SGrupo { get; set; }
        public string Etiqueta { get; set; }
        public string SMaterial { get; set; }
        public string SDescripcion { get; set; }
        public string SArchivo_Producto { get; set; }
        public string Url_Producto { get; set; }
        public string Tipo_Precio { get; set; }
        public string SPrecio { get; set; }
        public int NImporte_Orgi { get; set; }
        public int NImporte { get; set; }
        public string DFecha_Inicio { get; set; }
        public string Envio { get; set; }
        public string Moneda { get; set; }
        public int Cod_Categoria { get; set; }
        public int Cod_Genero { get; set; }
        public int Cod_Grupo { get; set; }
        public int Cod_Etiqueta { get; set; }
        public int Cod_Material { get; set; }
        public int IdMarca { get; set; }
    }

    public class ProductoIDServ
    {
        public int IdProducto { get; set; }
        public string SCodigo { get; set; }
        public string SProducto { get; set; }
        public string Categoria { get; set; }
        public string Genero { get; set; }
        public string SMarca { get; set; }
        public string Archivo_Marca { get; set; }
        public string Url_Marca { get; set; }
        public string Grupo { get; set; }
        public string Etiqueta { get; set; }
        public string Material { get; set; }
        public string SDescripcion { get; set; }
        public string Archivo_Producto { get; set; }
        public string Url_Producto { get; set; }
        public string Archivo_Talla { get; set; }
        public string Url_Talla { get; set; }
        public string Tipo_Precio { get; set; }
        public string SPrecio { get; set; }
        public int NImporte_Orgi { get; set; }
        public int NImporte { get; set; }
        public string DFecha_Inicio { get; set; }
        public string Envio { get; set; }
        public string Moneda { get; set; }
        public List<ColorIDServ> Color { get; set; }
        public List<ImagenIDServ> Imagen { get; set; }
        public List<TallaIDServ> Talla { get; set; }
        public List<StockIDServ> Stock { get; set; }
    }

    public class ColorIDServ
    {
        public int Cod_Color_0 { get; set; }
        public string Color_0 { get; set; }
        public string SArchivo_Imagen_0 { get; set; }
        public string Url_Imagen_0 { get; set; }
    }

    public class ImagenIDServ
    {
        public int IdImagen { get; set; }
        public string Color { get; set; }
        public int Cod_Color { get; set; }
        public int NOrden { get; set; }
        public string SDescripcion_Color { get; set; }
        public string Archivo_Produccto_Color { get; set; }
        public string Url_Color { get; set; }
    }

    public class TallaIDServ
    {
        public int Cod_Talla { get; set; }
        public string Talla { get; set; }
    }
    public class StockIDServ
    {
        public int Cod_Color { get; set; }
        public int Cod_Talla { get; set; }
        public int NStock { get; set; }
    }
    public class FiltroProducto
    {
        public int Tipo { get; set; }
        public string STag { get; set; }
        public string IdCategoria { get; set; }
        public string IdMarca { get; set; }
        public int Precio_Ini { get; set; }
        public int Precio_Fin { get; set; }
    }
}
