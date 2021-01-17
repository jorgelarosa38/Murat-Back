using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using ProjectMurat.Utilities;
using System;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/Services")]
    [ApiController]
    public class MuratController : Controller
    {
        private readonly ITablaMaestraLogic _tablamaestralogic;
        private readonly IComboLogic _combologic;
        private readonly IWriteOperationLogic _writeoperationlogic;
        private readonly IUserLogic _userlogic;
        public MuratController(IComboLogic combologic, ITablaMaestraLogic tablaMaestraLogic, IWriteOperationLogic writeoperationlogic, IUserLogic userlogic)
        {
            _combologic = combologic;
            _tablamaestralogic = tablaMaestraLogic;
            _writeoperationlogic = writeoperationlogic;
            _userlogic = userlogic;
        }

        [HttpGet]
        [Route("combo/ListarCombo/{TIPO:int}/{PARM1:maxlength(50)}/{PARM2:maxlength(50)}/{PARM3:maxlength(50)}/{PARM4:maxlength(50)}/{VALOR:int}")]
        public async Task<ActionResult<Response>> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _combologic.ListarCombo(TIPO, PARM1, PARM2, PARM3, PARM4, VALOR);

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
        [Route("tablaMaestra/GetTablaMaestra/{IDTABLA:int}")]
        public async Task<ActionResult<Response>> GetTablaMaestra(int IDTABLA)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _tablamaestralogic.GetTablaMaestra(IDTABLA);

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
        [Route("tablaMaestra/GetListaTabla/{IDTABLA:int}/{IDPADRE:int}/{SDETALLE:maxlength(100)}")]
        public async Task<ActionResult<Response>> GetListaTabla(int IDTABLA, int IDPADRE, int SDETALLE)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _tablamaestralogic.GetListaTabla(IDTABLA, IDPADRE, SDETALLE);

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
        [Route("tablaMaestra/GetListaTablaId/{IDDETALLE:int}")]
        public async Task<ActionResult<Response>> GetListaTablaId(int IDDETALLE)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _tablamaestralogic.GetListaTablaId(IDDETALLE);

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
        [Route("tablaMaestra/PostTabla")]
        public async Task<ActionResult<Response>> PostTabla([FromBody] TablaMaestra tablaMaestra)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _tablamaestralogic.PostTabla(tablaMaestra);

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
        [Route("user/GetUserFilter/{page:int}/{rows:int}/{userlogin:maxlength(20)}/{name:maxlength(120)}/{estate:int}")]
        public async Task<ActionResult<Response>> GetUserFilter(int page, int rows, string userlogin, string name, string estate)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                rpta = await _userlogic.UserFilter(page, rows, userlogin, name, estate);

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
        [Route("user/GetUserId/{userid:int}")]
        public async Task<ActionResult<Response>> GetUserId(int userid)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _userlogic.GetUserId(userid);

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
        [Route("user/PostUserMnt")]
        public async Task<ActionResult<Response>> PostUserMnt([FromBody] User user)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                rpta = await _userlogic.UserMnt(user);

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
        [Route("WriteOperation")]
        public async Task<ActionResult<Response>> WriteOperation([FromBody] WriteOperation writeOperation)
        {
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                writeOperation = (WriteOperation)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(writeOperation, writeOperation.GetType());
                rpta = await _writeoperationlogic.WriteOperation(writeOperation);

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
