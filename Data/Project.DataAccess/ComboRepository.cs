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
    public class ComboRepository : IComboRepository
    {
        protected string _connectionString;
        public ComboRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Combo>> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", TIPO);
            parameters.Add("@PARM1", PARM1);
            parameters.Add("@PARM2", PARM2);
            parameters.Add("@PARM3", PARM3);
            parameters.Add("@PARM4", PARM4);
            parameters.Add("@VALOR", VALOR);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Combo>("[dbo].[SPE_LIST_COMBO]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
