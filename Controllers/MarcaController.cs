using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using Murat.WebApi.Utilities;
using System;
using System.Threading.Tasks;

namespace Murat.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MarcaController : Controller
    {
        private readonly IMarcaLogic _marcalogic;
        public MarcaController(IMarcaLogic marcalogic)
        {
            _marcalogic = marcalogic;
        }

        [HttpGet]
        [Route("GetMarcas/{SMarca:maxlength(100)}")]
        public async Task<ActionResult<Response>> GetMarcas(string SMarca)
        {
            object rpta = new object();
            try
            {
                rpta = await _marcalogic.GetMarcas(SMarca);

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
        [Route("UpdMarca")]
        public async Task<ActionResult<Response>> UpdMarca([FromBody] Marca marca)
        {
            object rpta = new object();
            try
            {
                rpta = await _marcalogic.UpdMarca(marca);

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
