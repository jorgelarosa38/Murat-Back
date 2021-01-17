using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class ProductoRepository : IProductoRepository
    {
        protected string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Precio>> GetPrecio(int idProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDPRODUCTO", idProducto);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Precio>("[dbo].[SPE_LIST_EXT_PRODUCTO_PRECIO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<Producto>> GetProducto(string codigo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO", codigo);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Producto>("[dbo].[SPE_LIST_PRODUCTO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<Producto>> ListarProductos(int cod_Categoria, string sProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@COD_CATEGORIA", cod_Categoria);
            parameters.Add("@SPRODUCTO", sProducto);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Producto>("[dbo].[SPE_LIST_EXT_PRODUCTO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> UpdProducto(Producto producto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", producto.ACCION);
            parameters.Add("@IDPRODUCTO", producto.IdProducto);
            parameters.Add("@SCODIGO", producto.SCodigo);
            parameters.Add("@SPRODUCTO", producto.SProducto);
            parameters.Add("@COD_CATEGORIA", producto.Cod_Categoria);
            parameters.Add("@COD_GENERO", producto.Cod_Genero);
            parameters.Add("@IDMARCA", producto.IdMarca);
            parameters.Add("@COD_GRUPO", producto.Cod_Grupo);
            parameters.Add("@COD_ETIQUETA", producto.Cod_Etiqueta);
            parameters.Add("@COD_MATERIAL", producto.Cod_Material);
            parameters.Add("@SDESCRIPCION", producto.SDescripcion);
            parameters.Add("@SARCHIVO_TALLA", producto.SArchivo_Talla);
            parameters.Add("@BIMAGEN_TALLA", producto.BImagen_Talla);
            parameters.Add("@SARCHIVO_PRODUCTO", producto.SArchivo_Producto);
            parameters.Add("@BIMAGEN_PRODUCTO", producto.BImagen_Producto);
            parameters.Add("@IDUSUARIO", producto.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PRODUCTO]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<ResponseSql> UpdPrecio(Precio precio)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", precio.ACCION);
            parameters.Add("@IDPRECIO", precio.IdPrecio);
            parameters.Add("@IDPRODUCTO", precio.IdProducto);
            parameters.Add("@COD_PRECIO", precio.Cod_Precio);
            parameters.Add("@SPRECIO", precio.SPrecio);
            parameters.Add("@NIMPORTE_ORGI", precio.NImporte_orgi);
            parameters.Add("@NIMPORTE", precio.NImporte);
            parameters.Add("@DFECHA_INICIO", precio.DFecha_Inicio);
            parameters.Add("@COD_ENVIO", precio.Cod_Envio);
            parameters.Add("@IDUSUARIO", precio.IdUsuario);
            parameters.Add("@COD_MONEDA", precio.Cod_Moneda);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PRODUCTO_PRECIO]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<List<ImagenProducto>> GetImagen(int idProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDPRODUCTO", idProducto);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<ImagenProducto>("[dbo].[SPE_LIST_EXT_PRODUCTO_IMAGEN]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> UpdImagen(ImagenProducto imagenProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", imagenProducto.ACCION);
            parameters.Add("@IDIMAGEN", imagenProducto.IdImagen);
            parameters.Add("@IDPRODUCTO", imagenProducto.IdProducto);
            parameters.Add("@COD_COLOR", imagenProducto.Cod_Color);
            parameters.Add("@NORDEN", imagenProducto.NOrden);
            parameters.Add("@SDESCRIPCION", imagenProducto.SDescripcion);
            parameters.Add("@SARCHIVO", imagenProducto.SArchivo);
            parameters.Add("@BIMAGEN", imagenProducto.BImagen);
            parameters.Add("@IDUSUARIO", imagenProducto.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PRODUCTO_IMAGEN]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<ResponseSql> UpdTag(TagProducto tag)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", tag.ACCION);
            parameters.Add("@IDTAG", tag.IdTag);
            parameters.Add("@IDPRODUCTO", tag.IdProducto);
            parameters.Add("@COD_TAG", tag.Cod_Tag);
            parameters.Add("@STAG", tag.STag);
            parameters.Add("@SDECRIPCION", tag.SDecripcion);
            parameters.Add("@IDUSUARIO", tag.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PRODUCTO_TAG]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<List<TagProducto>> GetListaTags(int IdProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDPRODUCTO", IdProducto);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TagProducto>("[dbo].[SPE_LIST_EXT_PRODUCTO_TAG]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
