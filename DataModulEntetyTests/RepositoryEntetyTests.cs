using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModulEntety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces;

namespace DataModulEntety.Tests
{
    [TestClass()]
    public class RepositoryEntetyTests
    {
        private string conStr = @"Data Source=WS30\SRVWS30;Initial Catalog=Inline;Integrated Security=True";

        private IRepository Repository = new RepositoryEntety(@"Data Source=WS30\SRVWS30;Initial Catalog=Inline;Integrated Security=True");


        [TestMethod()]
        public void GetUsersTest()
        {
            int p=1;
            var pr = Repository.GetUsers("", 1, 1, ref p);


            foreach (User user in pr)
            {
                Console.WriteLine(user.idUser);
                Console.WriteLine(user.FirstName);
            }


        }


        [TestMethod()]
        public void GetUsersTest1()
        {
            var Db = new DataBaseContext(conStr);

            var pr = Db.Users;

            var countPage = pr.Count();

            foreach (User user in pr)
            {
                Console.WriteLine(user.idUser);
                Console.WriteLine(user.FirstName);
            }

            
        }

    }
}