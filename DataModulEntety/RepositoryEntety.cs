using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces;
using Interfaces.Models;

namespace DataModulEntety
{
    public class RepositoryEntety : IRepository
    {
        public RepositoryEntety(string conStr)
        {
            Db = new DataBaseContext(conStr);
        }

        public DataBaseContext Db { get; set; }

        public IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage)
        {
            if (name != "")
            {
                countPage = Db.Users.Count(f => f.FirstName.ToLower().Contains(name.ToLower()));
                return Db.Users
                            .OrderBy(p => p.idUser)
                            .Where(f => f.FirstName.ToLower().Contains(name.ToLower()) && f.State.Name == "В работе")
                            .Skip(pageSize * (page - 1)).Take(pageSize);
            }

            var pr = Db.Users.Where(f => f.State.Name == "В работе");
            countPage = pr.Count();
            return pr.OrderBy(p => p.idUser).Skip(pageSize * (page - 1)).Take(pageSize); ;

        }

        public AUser GerUser(int idUser = -1)
        {
            if (idUser == -1) return new User();
            return Db.Users.First(u => u.idUser == idUser);
        }
    }
}
