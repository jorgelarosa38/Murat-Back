using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Project.BusinessLogic.Helpers;
using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class SecurityLogic : ISecurityLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public SecurityLogic(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        public async Task<Response> ValidarAccesos(Credenciales credenciales)
        {
            Response response = new Response();
            OauthAccess oauth = new OauthAccess();
            try
            {
                List<DetalleUsuario> list = await _unitOfWork.Security.ValidarAccesos(credenciales);

                if (list != null)
                {
                    var secret = _config.GetSection("AppSettings").GetSection("Secret").Value;
                    string token = TokenGenerator.GenerateToken(list[0], secret);
                    oauth.token = token;
                    oauth.UserAccess = list;
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = oauth;
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
