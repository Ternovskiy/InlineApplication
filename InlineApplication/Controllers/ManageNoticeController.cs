using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces;
using Interfaces.Models.Notice;

namespace InlineApplication.Controllers
{
    public class ManageNoticeController : Controller
    {
        public ManageNoticeController(IRepository repository)
        {
            Repository = repository;
        }

        private IRepositoryNotice Repository { get; }


        // GET: ManageNotice
        public ActionResult Index()
        {
            return View(Repository.GetNotices());
        }

        // GET: ManageNotice/Create
        public ActionResult Create()
        {
            return View(Repository.GetNotice());
        }

        // POST: ManageNotice/Create
        [HttpPost]
        public ActionResult Create(Notice notice)
        {
            if(ModelState.IsValid)
            try
            {
                Repository.Save(notice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View(notice);
        }

        // GET: ManageNotice/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.GetNotice(id));
        }

        // POST: ManageNotice/Edit/5
        [HttpPost]
        public ActionResult Edit(Notice notice)
        {
            try
            {
                Repository.Save(notice);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageNotice/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repository.GetNotice(id));
        }

        // POST: ManageNotice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Repository.RemoveNotice(id);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
