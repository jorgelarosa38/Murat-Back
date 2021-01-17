using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface IPublicadoRepository
    {
        Task<ResponseSql> UpdPublicado(Publicado publicado);
        Task<object> GetPublicadoID(int cod_Operacion, int idDato);
        Task<List<ExtPublicado>> GetPublicado(int cod_Operacion);
    }
}
