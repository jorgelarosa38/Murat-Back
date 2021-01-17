using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> GetPrecio(int idProducto)
        {
            Response response = new Response();
            try
            {
                List<Precio> list = await _unitOfWork.Producto.GetPrecio(idProducto);

                if (list.Count > 0)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> GetProducto(string codigo)
        {
            Response response = new Response();
            try
            {
                List<Producto> list = await _unitOfWork.Producto.GetProducto(codigo);

                if (list.Count > 0)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListarProductos(int cod_Categoria, string sProducto)
        {
            Response response = new Response();
            try
            {
                List<Producto> list = await _unitOfWork.Producto.ListarProductos(cod_Categoria, sProducto);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.SArchivo_Talla != "")
                        {
                            item.UrlImagen_Talla = AuxiliarMethods.GenerarURL("Producto", item.SArchivo_Talla);
                        }

                        if (item.SArchivo_Producto != "")
                        {
                            item.UrlImagen_Producto = AuxiliarMethods.GenerarURL("Producto", item.SArchivo_Producto);
                        }
                    }
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> UpdProducto(Producto producto)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                if (producto.ACCION == "A" || producto.ACCION == "M")
                {
                    if (producto.BImagen_Talla != "" && producto.SArchivo_Talla != "")
                    {
                        AuxiliarMethods.Base64ToImage(producto.BImagen_Talla, producto.SArchivo_Talla, "Producto");
                    }
                    if (producto.BImagen_Producto != "" && producto.SArchivo_Producto != "")
                    {
                        AuxiliarMethods.Base64ToImage(producto.BImagen_Producto, producto.SArchivo_Producto, "Producto");
                    }
                }
                responsesql = await _unitOfWork.Producto.UpdProducto(producto);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<object> UpdPrecio(Precio precio)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                responsesql = await _unitOfWork.Producto.UpdPrecio(precio);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> GetImagen(int idProducto)
        {
            Response response = new Response();
            try
            {
                List<ImagenProducto> list = await _unitOfWork.Producto.GetImagen(idProducto);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.SArchivo != "")
                        {
                            string url_imagen = AuxiliarMethods.GenerarURL("Producto", item.SArchivo);
                            item.UrlImagen = url_imagen;
                        }
                    }
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> UpdImagen(ImagenProducto imagenProducto)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                if (imagenProducto.ACCION == "A" || imagenProducto.ACCION == "M")
                {
                    if (imagenProducto.SArchivo != "" && imagenProducto.BImagen != "")
                    {
                        AuxiliarMethods.Base64ToImage(imagenProducto.BImagen, imagenProducto.SArchivo, "Producto");
                    }
                }

                responsesql = await _unitOfWork.Producto.UpdImagen(imagenProducto);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> UpdTag(TagProducto tag)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                responsesql = await _unitOfWork.Producto.UpdTag(tag);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> GetListaTags(int IdProducto)
        {
            Response response = new Response();
            try
            {
                List<TagProducto> list = await _unitOfWork.Producto.GetListaTags(IdProducto);
                if (list.Count > 0)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
