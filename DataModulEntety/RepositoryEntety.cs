using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var pr = Db.Users
                            .OrderBy(p => p.idUser)
                            .Where(f=>f.LastName.ToLower().Contains(name.ToLower()))
                            .Skip(pageSize * (page - 1)).Take(pageSize);

                countPage = Db.Users.Count(f => f.LastName.ToLower().Contains(name.ToLower()));

                return pr;
            }
            else
            {
                var pr = Db.Users.OrderBy(p => p.idUser).Skip(pageSize * (page - 1)).Take(pageSize);

                countPage = Db.Users.Count();

                return pr;
            }
        }

        public AUser GerUser(int idUser)
        {
            return Db.Users.First(u => u.idUser == idUser);
        }
    }
}
