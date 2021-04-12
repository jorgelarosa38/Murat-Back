using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Project.DataAccess
{
    public class PublicadoRepository : IPublicadoRepository
    {
        protected string _connectionString;

        public PublicadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ExtPublicado>> GetPublicado(int cod_Operacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@COD_OPERACION", cod_Operacion);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<ExtPublicado>("[dbo].[SPE_LIST_EXT_PUBLICAR]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<object> GetPublicadoID(int cod_Operacion, int idDato)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@COD_OPERACION", cod_Operacion);
            parameters.Add("@IDDATO", idDato);

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = new object();

                if (cod_Operacion.Equals(1396))
                {
                    SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_EXT_PUBLICAR_ID]", parameters, commandType: CommandType.StoredProcedure);
                    List<PublicadoProducto> ListPubProd = reader.Read<PublicadoProducto>().ToList();
                    List<PubColor> PubColor = reader.Read<PubColor>().ToList();
                    List<PubImagen> PubImagen = reader.Read<PubImagen>().ToList();
                    List<PubProductoImagen> PubProdImagen = reader.Read<PubProductoImagen>().ToList();
                    List<PubTalla> PubTalla = reader.Read<PubTalla>().ToList();

                    if (ListPubProd.Count() > 0)
                    {
                        foreach (var pubProd in ListPubProd)
                        {
                            pubProd.Color = PubColor;
                            pubProd.Imagen = PubImagen;
                            pubProd.Producto_Imagen = PubProdImagen;
                            pubProd.Talla = PubTalla;
                        }
                        return ListPubProd;
                    }
                    return null;
                }
                else if (cod_Operacion.Equals(1397))
                {
                    SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_EXT_PUBLICAR_ID]", parameters, commandType: CommandType.StoredProcedure);
                    List<PublicadoMarca> ListPubMarca = reader.Read<PublicadoMarca>().ToList();

                    if (ListPubMarca.Count() > 0)
                    {
                        return ListPubMarca;
                    }
                    //result = (await connection.QueryAsync<PublicadoMarca>("[dbo].[SPE_LIST_EXT_PUBLICAR_ID]", parameters, commandType: CommandType.StoredProcedure)); ;

                    return null;
                }
                else if (cod_Operacion.Equals(1398))
                {
                    SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_EXT_PUBLICAR_ID]", parameters, commandType: CommandType.StoredProcedure);
                    List<PublicadoSlider> ListPubSlider = reader.Read<PublicadoSlider>().ToList();
                    if (ListPubSlider.Count() > 0)
                    {
                        return ListPubSlider;
                    }
                    //return (await connection.QueryAsync<PublicadoSlider>("[dbo].[SPE_LIST_EXT_PUBLICAR_ID]", parameters, commandType: CommandType.StoredProcedure));
                    return null;
                }
                return null;
            }
        }

        public async Task<ResponseSql> UpdPublicado(Publicado publicado)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@COD_OPERACION", publicado.Cod_operacion);
            parameters.Add("@IDDATO", publicado.IdDato);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PUBLICAR]", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
