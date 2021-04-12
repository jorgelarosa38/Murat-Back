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
    class MarcaRepository : IMarcaRepository
    {
        protected string _connectionString;

        public MarcaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Marca>> GetMarcas(string sMarca)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SMARCA", sMarca);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Marca>("[dbo].[SPE_LIST_EXT_MARCA]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> UpdMarca(Marca marca)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", marca.ACCION);
            parameters.Add("@IDMARCA", marca.IdMarca);
            parameters.Add("@SMARCA", marca.SMarca);
            parameters.Add("@SDESCRIPCION", marca.SDescripcion);
            parameters.Add("@SARCHIVO", marca.SArchivo);
            parameters.Add("@BIMAGEN", marca.BImagen);
            parameters.Add("@IDUSUARIO", marca.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_MARCA]", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
