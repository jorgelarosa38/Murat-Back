using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface ISliderRepository
    {
        Task<List<Slider>> GetSliders(string cod_Tipo);
        Task<ResponseSql> UpdSlider(Slider slider);
    }
}
