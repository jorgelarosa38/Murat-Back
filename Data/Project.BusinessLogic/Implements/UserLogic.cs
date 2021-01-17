using Project.BusinessLogic.Interfaces;
using Project.BusinessLogic.Utilities;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Implementations
{
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<object> UserFilter(int page, int rows, string userlogin, string name, string estate)
        {
            Response response = new Response();
            try
            {
                List<User> list = await _unitOfWork.User.UserFilter(page, rows, userlogin, name, estate);

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
        public async Task<object> GetUserId(int userid)
        {
            Response response = new Response();
            try
            {
                List<User> list = await _unitOfWork.User.UserId("03", userid, "");

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
        public async Task<object> UserMnt(User user)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();
            response.Message = "Ingresar los siguientes campos: ";
            int cont = 0;
            try
            {
                #region Validation
                if (user.ACCION == "A" || user.ACCION == "M")
                {
                    if (user.UserLogin == null || user.UserLogin == "")
                    {
                        response.Message = response.Message + " Usuario Login. ";
                        cont++;
                    }

                    if (user.Names == null || user.Names == "")
                    {
                        response.Message = response.Message + " Nombres. ";
                        cont++;
                    }

                    if (user.FirstLastName == null || user.FirstLastName == "")
                    {
                        response.Message = response.Message + " Apellido Paterno. ";
                        cont++;
                    }

                    if (user.SecondLastName == null || user.SecondLastName == "")
                    {
                        response.Message = response.Message + " Apellido Materno. ";
                        cont++;
                    }

                    if (user.Email == null || user.Email == "")
                    {
                        response.Message = response.Message + " Email. ";
                        cont++;
                    }

                    if (user.Email != "" && !ValidationEmail(user.Email))
                    {
                        response.Message = response.Message + " Email no válido. ";
                        cont++;
                    }

                    if (cont == 0)
                    {
                        string accion = user.ACCION == "A" ? "01" : "02";
                        List<User> list = await _unitOfWork.User.UserId(accion, user.UserId, user.UserLogin);

                        if (list.Count == 0)
                        {
                            responsesql = await _unitOfWork.User.UserMnt(user);
                            response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                            response.Message = responsesql.DESCR_ERR;
                            response.Data = responsesql.IDDATO;
                        }
                        else
                        {
                            response.Status = Constant.Error400;
                            response.Message = Constant.Existe;
                        }
                    }
                    else
                    {
                        response.Status = Constant.Error400;
                    }
                }
                else
                {
                    responsesql = await _unitOfWork.User.UserMnt(user);
                    response.Status = Int32.Parse(responsesql.DESCR_ERR);
                    response.Message = responsesql.DESCR_ERR;
                    response.Data = responsesql.IDDATO;
                }
                #endregion
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }
        static bool ValidationEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
