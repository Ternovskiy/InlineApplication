using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModul;
using InlineApplication.Models;
using Interfaces;
using Interfaces.Models;
using Interfaces.Models.Notice;
using Interfaces.Models.User;

namespace InlineApplication.Controllers
{
    public class ManageUserController : Controller
    {
        public ManageUserController(IRepository repository)
        {
            Repository = repository;
        }

        public IRepositoryUser Repository { get; set; }



        /// <summary>
        /// контент "Управление пользователями"
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }


        /// <summary>
        /// Вернет список пользователей и пагинатор
        /// </summary>
        /// <param name="name">ключ для поиска</param>
        /// <param name="pageSize">колличество польз. на странице</param>
        /// <param name="page">номер страницы</param>
        /// <returns></returns>
        public ActionResult SearchUser(string name, int pageSize, int? page)
        {
            int countP = 0;
            var p = Repository.GetUsers(name, pageSize, page ?? 1, ref countP);
            var pg = (page ?? 1);

            ViewBag.pageNumber = pg;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = countP;
            return PartialView(p);
        }

        /// <summary>
        /// Для редактирования и управления подписками пользователя
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public ActionResult DetalsUser(int idUser)
        {
            var r = new Random();
            ViewBag.img = @"/Content/img/" + r.Next(1, 5) + ".png";
            return PartialView(Repository.GerUser(idUser));
        }


        public ActionResult GetUserNotices(int idUser)
        {
            var s=Repository.GetUserNotices(idUser);
            var r = ((IRepositoryNotice) Repository)
                .GetNotices()
                .Select(n => new ViewUserNotice() { Notice = n, Signed = s.Any(_=>_.idNotice==n.idNotice) });
            ViewBag.UserId = idUser;
            return PartialView(r);
        }

        public void SaveUserNotice(int userId, int noticeId, bool signed)
        {
            Repository.SaveUserNotices(userId, noticeId, signed);
        }

        
        public ActionResult EditUser(int idUser=-1)
        {
            ViewBag.btnRetunn = true;
            return PartialView(Repository.GerUser(idUser));
        }

        public ActionResult CreateUser()
        {
            var r = new Random();
            ViewBag.img = @"/Content/img/" + r.Next(1, 5) + ".png";
            return PartialView(Repository.GerUser());
        }

        [HttpPost]
        public ActionResult SaveUser(AUser user)
        {
            if (ModelState.IsValid)
            {
                Repository.Save(user);
                return View("Index");
            }
            ViewBag.btnRetunn = false;
            return View("EditUser",user);
        }


        [HttpPost]
        public ActionResult RemoveUser(int idUser)
        {
            Repository.Remove(idUser);
            return View("Index");
        }
        
    }
}
