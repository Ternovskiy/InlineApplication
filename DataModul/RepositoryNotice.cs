using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Models.Notice;

namespace DataModul
{
    public partial class Repository
    {
        public IEnumerable<Notice> GetNotices()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Notice notice)
        {
            throw new System.NotImplementedException();
        }

        public Notice GetNotice(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveNotice(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<NoticeSendView> GetNoticeSendView()
        {
            throw new System.NotImplementedException();
        }

        public Task SendMessage(int noticeId, ISendingNotice sendingNotice)
        {
            throw new System.NotImplementedException();
        }
    }
}