using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface ITablaMaestraRepository
    {
        Task<List<TablaMaestra>> GetTablaMaestra(int IDTABLA);
        Task<List<TablaMaestraIDOut>> GetListaTabla(int IDTABLA, int IDPADRE, int SDETALLE);
        Task<List<TablaMaestraIDOut>> GetListaTablaId(int IDDETALLE);
        Task<ResponseSql> PostTabla(TablaMaestra tablaMaestra);

    }
}
