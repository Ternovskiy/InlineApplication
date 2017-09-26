using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Interfaces;
using Interfaces.Models.Notice;

namespace InlineApplication.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IRepository repository)
        {
            Repository = repository;
        }
        private IRepositoryNotice Repository { get; }

        public ActionResult Index()
        {
            IEnumerable<NoticeSendView> n = Repository.GetNoticeSendView();
            return View();
        }



        public async Task<string> SendNotice(int noticeId)
        {
            await Repository.SendMessage(noticeId);
            return DateTime.Now.ToString();
        }
    }
}