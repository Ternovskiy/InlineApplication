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
                new User(){Id = 1,Email = "dsfsdf",FirsName = "dsfsd",LastName = "dsfsd",MiddleName = "dfd"},
                new User(){Id = 2,Email = "dsfggfgsdf",FirsName = "dgggsfsd",LastName = "dsggfsd",MiddleName = "dfgggd"},
                new User(){Id = 3,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id =4 ,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id = 5,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id =6 ,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id = 7,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id = 8,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id = 9,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){Id = 10,Email = "Email",FirsName = "FirsName",LastName = "LastName",MiddleName = "MiddleName"},
            };
            countPage = users.Count;
            return users.Skip(pageSize*(page-1)).Take(pageSize);
        }

        public User GerUser(int idUser)
        {
            return new User() { Id = idUser, Email = "user"+ idUser, FirsName = "user", LastName = "user", MiddleName = "user" };
        }
    }
}
