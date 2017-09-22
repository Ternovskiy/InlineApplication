using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.Models;

namespace DataModul
{
    public class Repository:IRepository
    {
        public Repository(string conStr)
        {
            
        }


        public IEnumerable<User> GetUsers(string name, int pageSize, int page, ref int countPage)
        {
            var users=new List<User>()
            {
                new User(){Email = "dsfsdf",FirsName = "dsfsd",LastName = "dsfsd",MiddleName = "dfd"},
                new User(){Email = "dsfggfgsdf",FirsName = "dgggsfsd",LastName = "dsggfsd",MiddleName = "dfgggd"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
            };
            countPage = users.Count;
            return users.Skip(pageSize*(page-1)).Take(pageSize);
        }

        public User GerUser(int idUser)
        {
            return new User() {Email = "user", FirsName = "user", LastName = "user", MiddleName = "user" };
        }
    }
}
