using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using ProjectMurat.Utilities;
using System;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
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
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _sliderlogic.GetSliders(Cod_Tipo);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
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
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                slider = (Slider)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(slider, slider.GetType());
                rpta = await _sliderlogic.UpdSlider(slider);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }


    }
}
