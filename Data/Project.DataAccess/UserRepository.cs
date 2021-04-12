using Dapper;
using Project.Models;
using Project.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Project.DataAccess
{
    public class UserRepository : IUserRepository
    {
        protected string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<User>> UserFilter(int page, int rows, string userlogin, string name, string estate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@UserLogin", userlogin);
            parameters.Add("@Name", name);
            parameters.Add("@Estate", estate);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<User>("[dbo].[User_Filter]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ResponseSql> UserMnt(User user)
        {
            XmlDocument XmlDoc;
            XmlDoc = new XmlDocument();
            XmlElement element1 = XmlDoc.CreateElement("PAXLST_Message");
            XmlDoc.AppendChild(element1);
            XmlElement XmlUser = XmlDoc.CreateElement("Cabecera");
            element1.AppendChild(XmlUser);
            XmlUser.InnerXml = "<UserLogin></UserLogin><Names></Names><FirstLastName></FirstLastName><SecondLastName></SecondLastName><Phone></Phone>" +
                                "<Email></Email><CityId></CityId><CountryId></CountryId><Estate></Estate><AddUserId></AddUserId><UpdUserId></UpdUserId><Password></Password>";
            XmlUser.AppendChild(XmlDoc.CreateWhitespace("\r\n"));
            XmlUser["UserLogin"].InnerText = user.UserLogin;
            XmlUser["Names"].InnerText = user.Names;
            XmlUser["FirstLastName"].InnerText = user.FirstLastName;
            XmlUser["SecondLastName"].InnerText = user.SecondLastName;
            XmlUser["Phone"].InnerText = user.Phone;
            XmlUser["Email"].InnerText = user.Email;
            XmlUser["CityId"].InnerText = user.CityId.ToString();
            XmlUser["CountryId"].InnerText = user.CountryId.ToString();
            XmlUser["Estate"].InnerText = user.Estate;
            XmlUser["AddUserId"].InnerText = user.AddUserId.ToString();
            XmlUser["UpdUserId"].InnerText = user.UpdUserId.ToString();
            XmlUser["Password"].InnerText = user.Password;

            var parameters = new DynamicParameters();
            parameters.Add("@Accion", user.ACCION);
            parameters.Add("@IdDato", user.UserId);
            parameters.Add("@XmlDocument", XmlDoc.InnerXml, DbType.Xml);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SP_UDP_USER]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<User>> UserId(string action, int userid, string UserLogin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", action);
            parameters.Add("@UserId", userid);
            parameters.Add("@UserLogin", UserLogin);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<User>("[dbo].[User_Id]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
