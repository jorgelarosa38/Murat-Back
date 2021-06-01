using Microsoft.Extensions.Configuration;
using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class SliderLogic : ISliderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public SliderLogic(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<object> GetSliders(string cod_Tipo)
        {
            Response response = new Response();
            try
            {
                List<Slider> list = await _unitOfWork.Slider.GetSliders(cod_Tipo);

                if (list.Count > 0)
                {
                    string directory = _config.GetSection("AppSettings").GetSection("directory").Value;
                    foreach (var item in list)
                    {
                        if (item.SArchivo != "")
                        {
                            string url_imagen = AuxiliarMethods.GenerarURL(directory,"Slider", item.SArchivo);
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

        public async Task<object> UpdSlider(Slider slider)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                if (slider.ACCION == "A" || slider.ACCION == "M")
                {
                    string directory = _config.GetSection("AppSettings").GetSection("directory").Value;
                    slider.SArchivo = slider.SArchivo.ToString().Trim();
                    slider.BImagen = slider.BImagen.ToString().Trim();
                    if (slider.SArchivo != "" && slider.BImagen != "")
                    {
                        AuxiliarMethods.Base64ToImage(directory, slider.BImagen, slider.SArchivo, "Slider");
                    }
                }

                responsesql = await _unitOfWork.Slider.UpdSlider(slider);
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
