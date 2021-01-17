using Project.Models;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
    public interface IMarcaLogic
    {
        Task<object> GetMarcas(string sMarca);
        Task<object> UpdMarca(Marca marca);
    }
}
