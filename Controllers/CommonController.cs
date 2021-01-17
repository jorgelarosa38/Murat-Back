using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using ProjectMurat.Utilities;
using System;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommonController : Controller
    {
        private readonly ICommonLogic _commonlogic;
        public CommonController(ICommonLogic commonlogic)
        {
            _commonlogic = commonlogic;
        }

        [HttpGet]
        [Route("GetNroImagen/{Tipo:int}/{Id1:int}/{Id2:int}/{Id3:int}")]
        public async Task<ActionResult<Response>> GetNroImagen(int Tipo, int Id1, int Id2, int Id3)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _commonlogic.GetNroImagen(Tipo, Id1, Id2, Id3);

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
