using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces;
using Interfaces.Models;
using Interfaces.Models.Notice;

namespace DataModulEntety
{
    public partial class RepositoryEntety : IRepository
    {
        public RepositoryEntety(string conStr)
        {
            Db = new DataBaseContext(conStr);
        }

        public DataBaseContext Db { get; set; }

        public IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage)
        {
            if (name != "")
            {
                countPage = Db.Users.Count(f => f.FirstName.ToLower().Contains(name.ToLower()) && f.State.Name == "В работе");
                return Db.Users
                            .OrderBy(p => p.idUser)
                            .Where(f => f.FirstName.ToLower().Contains(name.ToLower()) && f.State.Name == "В работе")
                            .Skip(pageSize * (page - 1)).Take(pageSize);
            }

            var pr = Db.Users.Where(f => f.State.Name == "В работе");
            countPage = pr.Count();
            return pr.OrderBy(p => p.idUser).Skip(pageSize * (page - 1)).Take(pageSize); ;

        }

        public AUser GerUser(int idUser = -1)
        {
            if (idUser == -1) return new User();
            return Db.Users.First(u => u.idUser == idUser);
        }

        public bool Save(AUser user)
        {
            if (user.idUser == 0)
            {
                var u=new User(user);
                Db.Users.Add(u);
            }
            else
            {
                var u = Db.Users.First(_ => _.idUser == user.idUser);
                if (u == null) return false;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.MiddleName = user.MiddleName;
                u.Email = user.Email;
            }
                Db.SaveChanges();
                return true;
        }

        public bool Remove(int userId)
        {
            var u = Db.Users.First(_ => _.idUser == userId);
            if (u == null) return false;
            u.idState = 2;
            Db.SaveChanges();
            return true;
        }

        public IEnumerable<Notice> GetUserNotices(int userId)
        {
            return Db.Users.First(_ => _.idUser == userId)
                .Notices.Where(_ => _.idState == 1);
        }

        public bool SaveUserNotices(int userId, int noticeId, bool signed)
        {
            var user=Db.Users.First(u => u.idUser == userId);
            var notice = Db.Notices.First(n => n.idNotice == noticeId);
            if (signed)
            {
                
                if (!notice.Users.Any(u => u.idUser == userId))
                {
                    notice.Users.Add(user);
                    Db.SaveChanges();
                }
                return true;
            }
            if (notice.Users.Any(u => u.idUser == userId))
            {
                notice.Users.Remove(user);
                Db.SaveChanges();
            }
            return true;
        }

        public  Task SendMessage(int noticeId, ISendingNotice sendingNotice)
        {
            return Task.Factory.StartNew(()=>
            {
                var notice =Db.Notices.First(n=>n.idNotice==noticeId);
                var users = notice.Users.Where(u => u.idState == 1);
                var locker = new object();
                Parallel.ForEach(users, ((user, state) =>
                {
                    try
                    {
                        sendingNotice.Send(notice, user);
                        lock (locker)
                        {
                            Db.Histories.Add(new Histories()
                            {
                                idNotice = noticeId,
                                idState = 3,
                                idUser = user.idUser,
                                Date = DateTime.Now
                            });
                            Db.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        lock (locker)
                        {
                            Db.Histories.Add(new Histories()
                            {
                                idNotice = noticeId,
                                idState = 4,
                                Comment = e.Message,
                                idUser = user.idUser,
                                Date = DateTime.Now
                            });
                            Db.SaveChanges();
                        }
                    }
                }));
            });
        }
    }
}
