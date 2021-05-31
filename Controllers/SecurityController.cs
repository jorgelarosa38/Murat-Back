using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using Murat.WebApi.Utilities;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using static Project.BusinessLogic.Utilities.AuxiliarMethods;

namespace Murat.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly ISecurityLogic _securitylogic;

        public SecurityController(ISecurityLogic securitylogic)
        {
            _securitylogic = securitylogic;
        }

        [HttpPost]
        [Route("ValidarAccesos")]
        public async Task<ActionResult<Response>> ValidarAccesos(Credenciales credenciales)
        {
            object rpta = new object();
            try
            {
                credenciales = (Credenciales)ValidateParameters(credenciales, credenciales.GetType());
                rpta = await _securitylogic.ValidarAccesos(credenciales);

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
