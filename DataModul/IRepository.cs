using System.Collections.Generic;
using DataModul.Models;

namespace DataModul
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers(string name, int pageSize, int page, ref int countPage);
        User GerUser(int idUser);
    }
}