using Dapper;
using Microsoft.Extensions.Configuration;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Project.DataAccess
{
    public class SecurityRepository : ISecurityRepository
    {
        protected string _connectionString;
        public IConfiguration Configuration { get; }

        public SecurityRepository(string connectionString, IConfiguration _configuration)
        {
            _connectionString = connectionString;
            Configuration = _configuration;
        }

        public async Task<List<DetalleUsuario>> ValidarAccesos(Credenciales credenciales)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@USUARIO", credenciales.usuario);
            parameters.Add("@CONTRASENA", credenciales.contraseña);

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_EXT_LOGIN]", parameters, commandType: CommandType.StoredProcedure);
                List<DetalleUsuario> DetalleUsuario = reader.Read<DetalleUsuario>().ToList();
                List<Accesos> Accesos = reader.Read<Accesos>().ToList();
                List<Accesos> Config = reader.Read<Accesos>().ToList();

                if (DetalleUsuario.Count > 0)
                {
                    var maintence_url = Configuration["AppSettings:Maintence"];
                    foreach (var item in DetalleUsuario)
                    {
                        item.Accesos = Accesos;
                        foreach (var opcion in Accesos)
                        {
                            if (opcion.Name.Equals("CONFIGURACION"))
                            {
                                opcion.Children = Config;
                            }
                        }
                    }
                }
                return DetalleUsuario;
            }
        }
    }
}
