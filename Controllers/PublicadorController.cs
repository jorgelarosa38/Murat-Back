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
    public class PublicadorController : Controller
    {
        private readonly IPublicadoLogic _publicadologic;
        public PublicadorController(IPublicadoLogic publicadologic)
        {
            _publicadologic = publicadologic;
        }


        [HttpPost]
        [Route("UpdPublicado")]
        public async Task<ActionResult<Response>> UpdPublicado([FromBody] Publicado publicado)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                publicado = (Publicado)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(publicado, publicado.GetType());
                rpta = await _publicadologic.UpdPublicado(publicado);

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

        [HttpGet]
        [Route("GetPublicadoID/{Cod_Operacion:int}/{IdDato:int}")]
        public async Task<ActionResult<Response>> GetPublicadoID(int Cod_Operacion, int IdDato)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _publicadologic.GetPublicadoID(Cod_Operacion, IdDato);

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

        [HttpGet]
        [Route("GetPublicado/{Cod_Operacion:int}")]
        public async Task<ActionResult<Response>> GetPublicado(int Cod_Operacion)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _publicadologic.GetPublicado(Cod_Operacion);

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
