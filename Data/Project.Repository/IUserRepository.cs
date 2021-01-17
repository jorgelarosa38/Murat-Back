using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> UserFilter(int page, int rows, string userlogin, string name, string estate);
        Task<ResponseSql> UserMnt(User user);
        Task<List<User>> UserId(string action, int userid, string UserLogin);
    }
}
