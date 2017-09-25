using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces;
using Interfaces.Models.Notice;

namespace DataModulEntety
{
    public partial class RepositoryEntety : IRepository
    {
        public IEnumerable<Notice> GetNotices()
        {
            return Db.Notices.Where(_=>_.idState==1);
        }

        public bool Save(Notice notice)
        {
            if (notice.idNotice == 0)
            {
                var n = new NoticeEntety(notice);
                Db.Notices.Add(n);
            }
            else
            {
                var n = Db.Notices.First(_ => _.idNotice == notice.idNotice);
                if (n == null) return false;
                n.Name = notice.Name;
            }
            Db.SaveChanges();
            return true;
        }

        public Notice GetNotice(int id=-1)
        {
            if(id==-1)return new NoticeEntety();
            return Db.Notices.First(_ => _.idNotice == id);
        }

        public bool RemoveNotice(int id)
        {
            var n = Db.Notices.First(_ => _.idNotice == id);
            if (n == null) return false;
            n.idState = 2;
            Db.SaveChanges();
            return true;
        }
    }
}
