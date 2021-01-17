using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class TablaMaestraLogic : ITablaMaestraLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public TablaMaestraLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<object> GetTablaMaestra(int IDTABLA)
        {
            Response response = new Response();
            try
            {
                List<TablaMaestra> list = await _unitOfWork.TablaMaestra.GetTablaMaestra(IDTABLA);

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

        public async Task<object> GetListaTabla(int IDTABLA, int IDPADRE, int SDETALLE)
        {
            Response response = new Response();
            try
            {
                List<TablaMaestraIDOut> list = await _unitOfWork.TablaMaestra.GetListaTabla(IDTABLA, IDPADRE, SDETALLE);

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

        public async Task<object> GetListaTablaId(int IDDETALLE)
        {
            Response response = new Response();
            try
            {
                List<TablaMaestraIDOut> list = await _unitOfWork.TablaMaestra.GetListaTablaId(IDDETALLE);

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

        public async Task<object> PostTabla(TablaMaestra tablaMaestra)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                responsesql = await _unitOfWork.TablaMaestra.PostTabla(tablaMaestra);
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
