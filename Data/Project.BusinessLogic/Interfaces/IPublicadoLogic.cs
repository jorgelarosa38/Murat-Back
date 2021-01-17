using Project.Models;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
    public interface IPublicadoLogic
    {
        Task<object> UpdPublicado(Publicado publicado);
        Task<object> GetPublicadoID(int cod_Operacion, int idDato);
        Task<object> GetPublicado(int cod_Operacion);
    }
}
