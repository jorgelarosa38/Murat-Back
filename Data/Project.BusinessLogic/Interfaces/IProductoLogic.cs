using Project.Models;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
    public interface IProductoLogic
    {
        Task<object> UpdProducto(Producto producto);
        Task<object> ListarProductos(int cod_Categoria, string sProducto);
        Task<object> GetProducto(string codigo);
        Task<object> GetPrecio(int idProducto);
        Task<object> UpdPrecio(Precio precio);
        Task<object> GetImagen(int idProducto);
        Task<object> UpdImagen(ImagenProducto imagenProducto);
        Task<object> UpdTag(TagProducto tag);
        Task<object> GetListaTags(int idProducto);
    }
}
