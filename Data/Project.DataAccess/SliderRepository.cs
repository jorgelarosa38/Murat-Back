using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class SliderRepository : ISliderRepository
    {
        protected string _connectionString;

        public SliderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Slider>> GetSliders(string cod_Tipo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@COD_TIPO", cod_Tipo);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Slider>("[dbo].[SPE_LIST_EXT_SLIDER]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> UpdSlider(Slider slider)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", slider.ACCION);
            parameters.Add("@IDSLIDER", slider.IdSlider);
            parameters.Add("@COD_TIPO", slider.Cod_Tipo);
            parameters.Add("@NORDEN", slider.NOrden);
            parameters.Add("@SDESCRIPCION", slider.SDescripcion);
            parameters.Add("@COD_URL", slider.Cod_Url);
            parameters.Add("@SURL", slider.SUrl);
            parameters.Add("@COD_TIPO_ARCHIVO", slider.Cod_Tipo_Archivo);
            parameters.Add("@COD_UBICACION", slider.Cod_Ubicacion);
            parameters.Add("@SARCHIVO", slider.SArchivo);
            parameters.Add("@BIMAGEN", slider.BImagen);
            parameters.Add("@IDUSUARIO", slider.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_SLIDER]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
