using System.Collections.Generic;
using Interfaces.Models;

namespace Interfaces
{
    public interface IRepository
    {
        IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage);
        AUser GerUser(int idUser);
    }
}