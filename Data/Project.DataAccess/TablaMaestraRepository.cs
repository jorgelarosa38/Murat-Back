using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class TablaMaestraRepository : ITablaMaestraRepository
    {
        protected string _connectionString;
        public TablaMaestraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<TablaMaestra>> GetTablaMaestra(int IDTABLA)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TABLA", IDTABLA);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TablaMaestra>("[dbo].[SPE_LIST_TABLA_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<TablaMaestraIDOut>> GetListaTabla(int IDTABLA, int IDPADRE, int SDETALLE)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDTABLA", IDTABLA);
            parameters.Add("@IDPADRE", IDPADRE);
            parameters.Add("@SDETALLE", SDETALLE);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TablaMaestraIDOut>("[dbo].[SPE_LIST_TABLA]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<TablaMaestraIDOut>> GetListaTablaId(int IDDETALLE)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDDETALLE", IDDETALLE);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TablaMaestraIDOut>("[dbo].[SPE_LIST_TABLA_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> PostTabla(TablaMaestra tablaMaestra)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", tablaMaestra.ACCION);
            parameters.Add("@IDDETALLE", tablaMaestra.IDDETALLE);
            parameters.Add("@IDTABLA", tablaMaestra.IDTABLA);
            parameters.Add("@SDETALLE", tablaMaestra.SDETALLE);
            parameters.Add("@FILLER1", tablaMaestra.FILLER1);
            parameters.Add("@FILLER2", tablaMaestra.FILLER2);
            parameters.Add("@FILLER3", tablaMaestra.FILLER3);
            parameters.Add("@IDPADRE", tablaMaestra.IDPADRE);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_TABLA_DETALLE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
