using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class CommonRepository : ICommonRepository
    {
        protected string _connectionString;
        public CommonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<MenuBar>> GetMenuBar(int Tipo, int Id1, int Id2)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", Tipo);
            parameters.Add("@ID1", Id1);
            parameters.Add("@ID2", Id2);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<MenuBar>("[dbo].[SPE_LIST_MENU]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<ListNroImagen>> GetNroImagen(int tipo, int id1, int id2, int id3)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", tipo);
            parameters.Add("@ID1", id1);
            parameters.Add("@ID2", id2);
            parameters.Add("@ID3", id3);

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_NRO_IMAGEN]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                List<ListNroImagen> ListNroImagen = reader.Read<ListNroImagen>().ToList();
                List<Archivo> ListArchivo = reader.Read<Archivo>().ToList();


                if (ListNroImagen.Count > 0)
                {
                    foreach (var imagen in ListNroImagen)
                    {
                        imagen.Archivo_Imagenes = ListArchivo;
                    }
                    return ListNroImagen;
                }
                return null;
            }
        }

    }
}
