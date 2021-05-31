using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using Murat.WebApi.Utilities;
using System;
using System.Threading.Tasks;
using static Project.BusinessLogic.Utilities.AuxiliarMethods;

namespace Murat.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SliderController : Controller
    {
        private readonly ISliderLogic _sliderlogic;
        public SliderController(ISliderLogic sliderlogic)
        {
            _sliderlogic = sliderlogic;
        }

        [HttpGet]
        [Route("GetSliders/{Cod_Tipo:int}")]
        public async Task<ActionResult<Response>> GetSliders(string Cod_Tipo)
        {
            object rpta = new object();
            try
            {
                rpta = await _sliderlogic.GetSliders(Cod_Tipo);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("UpdSlider")]
        public async Task<ActionResult<Response>> UpdSlider([FromBody] Slider slider)
        {
            object rpta = new object();
            try
            {
                slider = (Slider)ValidateParameters(slider, slider.GetType());
                rpta = await _sliderlogic.UpdSlider(slider);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }
    }
}
