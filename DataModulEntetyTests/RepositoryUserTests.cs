using System;
using System.Linq;
using DataModulEntety;
using DataModulEntety.Model;
using Interfaces;
using Interfaces.Models.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataModulEntetyTests
{
    [TestClass()]
    public class RepositoryEntetyTests
    {
        private const string conStr = @"Data Source=WS30\SRVWS30;Initial Catalog=Inline;Integrated Security=True";

        //private IRepository Repository = new RepositoryEntety(conStr);
        private IRepositoryUser Repository = new RepositoryEntety(conStr);


        [TestMethod()]
        public void GetUsersTest()
        {
            int p=0;
            var pr = Repository.GetUsers("", 10, 1, ref p).ToList();


            Assert.AreEqual(5,p);
            Assert.AreEqual(5,pr.Count());


            //foreach (User user in pr)
            //{
            //    Console.WriteLine(user.idUser);
            //    Console.WriteLine(user.FirstName);
            //}


        }

        [TestMethod()]
        public void GetUsersSerchTest()
        {
            int p = 0;
            var pr = Repository.GetUsers("Ивано", 10, 1, ref p).ToList();


            Assert.AreEqual(2, p);
            Assert.AreEqual(2, pr.Count());


        }

        [TestMethod()]
        public void GetUsersTest1()
        {
            var Db = new DataBaseContext(conStr);

            //var pr = Db.Users;

            //var countPage = pr.Count();

            //foreach (User user in pr)
            //{
            //    Console.WriteLine(user.idUser);
            //    Console.WriteLine(user.FirstName);
            //}

            //var name = "иван";
            //Console.WriteLine(Db.Users.Count(f => f.LastName.ToLower().Contains(name.ToLower())));

            //Console.WriteLine(Repository.GerUser(5));

            //Console.WriteLine(Db.States.Count());

            //Console.WriteLine(Db.Users.First(_ => _.idUser == 5).idState);

            //var r=Db.Users.ToList();

            //foreach (var u in Db.States.First(_ => _.idState == 2).Notices)
            //{
            //    Console.WriteLine(u);
            //}

            //var s= Db.States.ToList();

            //var us = Db.Users.First(_ => _.idUser == 5);

            //Console.WriteLine(us);
            //Console.WriteLine(us.State.Name);

            //Console.WriteLine(Db.Users.First(_ => _.idUser == 5).State.Name);







            var u = Db.Users.First(_ => _.idUser == 3);
            Console.WriteLine(u.State.Name);
            var nu = u.Notices;
            foreach (var item in nu)
            {
                Console.WriteLine(item.Name);
            }



            //var n = Db.Notices.First(_ => _.idNotice == 1);

            //Db.Users.First(_ => _.idUser == 3).Notices.Add(n);

            //Db.SaveChanges();

        }




        [TestMethod]
        public void GetUserObjTest()
        {
            var u = Repository.GerUser();

            Assert.AreEqual(u.idUser,0);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var u = Repository.GerUser(3);

            Assert.AreEqual(u.idUser, 3);
        }

        [TestMethod]
        public void UserSaveTest()
        {
            int count = 0;

            Repository.GetUsers("", 1,1,ref count);
            var u=Repository.GerUser();
            u.FirstName = "testFN";
            u.LastName = "LN";
            u.MiddleName = "MN";
            u.Email = "t@t.t";
            Repository.Save(u);

            var count2=0;
            Repository.GetUsers("", 1,1,ref count2);
            Assert.AreEqual(count+1,count2);
        }


        [TestMethod]
        public void UserEditTest()
        {
            var u = Repository.GerUser(10);
            u.FirstName = "edit";
            u.LastName = "editLN";
            u.MiddleName = "editMN";
            u.Email = "edit@t.t";
            Repository.Save(u);
        }

        [TestMethod]
        public void UserRemove()
        {
            Repository.Remove(10);
        }


        [TestMethod]
        public void TestGetUserNitoces()
        {
            var un = Repository.GetUserNotices(3);

            Assert.AreEqual(1,un.Count());
        }
    }
}