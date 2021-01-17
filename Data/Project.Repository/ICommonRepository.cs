using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface ICommonRepository
    {
        Task<List<ListNroImagen>> GetNroImagen(int tipo, int id1, int id2, int id3);
        Task<List<MenuBar>> GetMenuBar(int tipo, int id1, int id2);
    }
}
