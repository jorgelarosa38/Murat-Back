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
            object rpta = new object();
            try
            {
                publicado = (Publicado)ValidateParameters(publicado, publicado.GetType());
                rpta = await _publicadologic.UpdPublicado(publicado);

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

        [HttpGet]
        [Route("GetPublicadoID/{Cod_Operacion:int}/{IdDato:int}")]
        public async Task<ActionResult<Response>> GetPublicadoID(int Cod_Operacion, int IdDato)
        {
            object rpta = new object();
            try
            {
                rpta = await _publicadologic.GetPublicadoID(Cod_Operacion, IdDato);

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

        [HttpGet]
        [Route("GetPublicado/{Cod_Operacion:int}")]
        public async Task<ActionResult<Response>> GetPublicado(int Cod_Operacion)
        {
            object rpta = new object();
            try
            {
                rpta = await _publicadologic.GetPublicado(Cod_Operacion);

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
