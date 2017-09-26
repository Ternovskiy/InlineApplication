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

        public HomeController(IRepository repository, ISendingNotice sendingNotice)
        {
            Repository = repository;
            SendingNotice = sendingNotice;
        }
        private IRepositoryNotice Repository { get; }
        private ISendingNotice SendingNotice { get; }



        public ActionResult Index()
        {
            return View(Repository.GetNoticeSendView());
        }



        public async Task<string> SendNotice(int noticeId)
        {
            await Repository.SendMessage(noticeId, SendingNotice);
            return DateTime.Now.ToString();
        }
    }
}