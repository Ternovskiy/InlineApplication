using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModul;
using Interfaces;

namespace InlineApplication.Controllers
{
    public class ManageUserController : Controller
    {
        public ManageUserController(IRepository repository)
        {
            Repository = repository;
        }

        public IRepository Repository { get; set; }


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







        #region dhsfjahsdfjhasdjkfhasdjkfh

        // GET: ManageUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
