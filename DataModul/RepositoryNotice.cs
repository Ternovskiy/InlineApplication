using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Models.Notice;

namespace DataModul
{
    public partial class Repository
    {
        public IEnumerable<Notice> GetNotices()
        {
            var notices = new List<Notice>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"select * from Notices where idState=1";
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notices.Add(new Notice()
                            {
                                idNotice = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return notices;
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