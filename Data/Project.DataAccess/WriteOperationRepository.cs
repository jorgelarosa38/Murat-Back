using Dapper;
using Project.Models;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class WriteOperationRepository : IWriteOperationRepository
    {
        protected string _connectionString;
        public WriteOperationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<WriteOutput>> WriteOperation(WriteOperation writeOperation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", writeOperation.Accion);
            parameters.Add("@IDDATO", writeOperation.IdDato);
            parameters.Add("@XMLDatos", writeOperation.XML);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<WriteOutput>("[dbo].[SP_UDP_CLIENTE]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
