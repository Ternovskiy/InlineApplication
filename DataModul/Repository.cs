using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.Models;
using Interfaces;
using Interfaces.Models;

namespace DataModul
{
    public class Repository: IRepository
    {
        public Repository(string conStr)
        {
            
        }


        public IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage)
        {
            var users=new List<AUser>()
            {
                new User(){idUser = 1,Email = "dsfsdf",FirstName = "dsfsd",LastName = "dsfsd",MiddleName = "dfd"},
                new User(){idUser = 2,Email = "dsfggfgsdf",FirstName = "dgggsfsd",LastName = "dsggfsd",MiddleName = "dfgggd"},
                new User(){idUser = 3,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser =4 ,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser = 5,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser =6 ,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser = 7,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser = 8,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser = 9,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
                new User(){idUser = 10,Email = "Email",FirstName = "FirstName",LastName = "LastName",MiddleName = "MiddleName"},
            };
            countPage = users.Count;
            return users.Skip(pageSize*(page-1)).Take(pageSize);
        }

        public AUser GerUser(int idUser)
        {
            return new User() { idUser = idUser, Email = "user"+ idUser, FirstName = "user", LastName = "user", MiddleName = "user" };
        }
    }
}
