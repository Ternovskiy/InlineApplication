using System;
using System.Linq;
using DataModulEntety;
using Interfaces.Models.Notice;
using Interfaces.Models.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataModulEntetyTests
{
    [TestClass]
    public class RepositoryNoticeTests
    {
        private const string conStr = @"Data Source=WS30\SRVWS30;Initial Catalog=Inline;Integrated Security=True";
        
        private IRepositoryNotice Repository = new RepositoryEntety(conStr);

        [TestMethod]
        public void TestGetNotices()
        {
            var n=Repository.GetNotices();

            Assert.AreEqual(2,n.Count());
        }


        [TestMethod]
        public void TestGetViewSendNotice()
        {
            var n = Repository.GetNoticeSendView();

            foreach (NoticeSendView item in n)
            {
                
                var d = item.DataLastSended ==new DateTime() ? "null" : item.DataLastSended.ToString();
                var s = $"{item.idNotice} - {item.Name} - {d}";
                Console.WriteLine(s);
            }

        }
    }
}
