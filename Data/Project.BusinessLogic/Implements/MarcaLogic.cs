using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class MarcaLogic : IMarcaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarcaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> GetMarcas(string sMarca)
        {
            Response response = new Response();
            try
            {
                List<Marca> list = await _unitOfWork.Marca.GetMarcas(sMarca);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.SArchivo != "")
                        {
                            string url_imagen = AuxiliarMethods.GenerarURL("Marca", item.SArchivo);
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

        public async Task<object> UpdMarca(Marca marca)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                if (marca.ACCION == "A" || marca.ACCION == "M")
                {
                    marca.SArchivo = marca.SArchivo.ToString().Trim();
                    marca.BImagen = marca.BImagen.ToString().Trim();
                    if (marca.SArchivo != "" && marca.BImagen != "")
                    {
                        AuxiliarMethods.Base64ToImage(marca.BImagen, marca.SArchivo, "Marca");
                    }
                }
                responsesql = await _unitOfWork.Marca.UpdMarca(marca);
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
    }
}
