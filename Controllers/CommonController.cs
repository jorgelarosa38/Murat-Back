using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Murat.WebApi.Utilities;
using System;
using System.Threading.Tasks;

namespace Murat.WebApi.Controllers
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
            object rpta = new object();
            try
            {
                rpta = await _commonlogic.GetNroImagen(Tipo, Id1, Id2, Id3);

                if (rpta == null) {
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
