using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogic.Interfaces;
using Project.Models;
using ProjectMurat.Utilities;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Project.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProductoLogic _productologic;
        public ProductoController(IProductoLogic productologic)
        {
            _productologic = productologic;
        }

        [HttpGet]
        [Route("GetProducto/{Codigo:maxlength(20)}")]
        public async Task<ActionResult<Response>> GetProducto(string Codigo)
        {
            object rpta = new object();
            try
            {
                rpta = await _productologic.GetProducto(Codigo);

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
        [Route("precio/GetPrecio/{IdProducto:int}")]
        public async Task<ActionResult<Response>> GetPrecio(int IdProducto)
        {
            object rpta = new object();
            try
            {
                rpta = await _productologic.GetPrecio(IdProducto);

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
        [Route("imagen/GetImagen/{IdProducto:int}")]
        public async Task<ActionResult<Response>> GetImagen(int IdProducto)
        {
            object rpta = new object();
            try
            {
                rpta = await _productologic.GetImagen(IdProducto);

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
        [Route("GetListaProductos/{Cod_Categoria:int}/{SProducto::maxlength(100)}")]
        public async Task<ActionResult<Response>> GetListaProductos(int Cod_Categoria, string SProducto)
        {
            object rpta = new object();
            try
            {
                rpta = await _productologic.ListarProductos(Cod_Categoria, SProducto);

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
        [Route("tag/GetListaTags/{IdProducto:int}")]
        public async Task<ActionResult<Response>> GetListaTags(int IdProducto)
        {
            object rpta = new object();
            try
            {
                rpta = await _productologic.GetListaTags(IdProducto);

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
        [Route("UpdProducto")]
        public async Task<ActionResult<Response>> UpdProducto([FromBody] Producto producto)
        {
            object rpta = new object();
            try
            {
                producto = (Producto)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(producto, producto.GetType());
                rpta = await _productologic.UpdProducto(producto);

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
        [Route("precio/UpdPrecio")]
        public async Task<ActionResult<Response>> UpdPrecio([FromBody] Precio precio)
        {
            object rpta = new object();
            try
            {
                precio = (Precio)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(precio, precio.GetType());
                rpta = await _productologic.UpdPrecio(precio);

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
        [Route("imagen/UpdImagen")]
        public async Task<ActionResult<Response>> UpdImagen([FromBody] ImagenProducto imagenProducto)
        {
            object rpta = new object();
            try
            {
                imagenProducto = (ImagenProducto)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(imagenProducto, imagenProducto.GetType());
                rpta = await _productologic.UpdImagen(imagenProducto);

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
        [Route("tag/UpdTag")]
        public async Task<ActionResult<Response>> UpdTag([FromBody] TagProducto tag)
        {
            object rpta = new object();
            try
            {
                tag = (TagProducto)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(tag, tag.GetType());
                rpta = await _productologic.UpdTag(tag);

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
