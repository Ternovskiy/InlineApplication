using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.Models;
using Interfaces;
using Interfaces.Models;
using Interfaces.Models.Notice;

namespace DataModul
{
    public partial class Repository: IRepository
    {
        public Repository(string conStr)
        {
            ConnectionString = conStr;
        }

        private string ConnectionString { get; }

        public IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage)
        {
            var users=new List<AUser>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    //cmd.CommandText = @"EXEC GetUserPages		@name,	@pageSize,	@page,	@countPage";
                    cmd.CommandText = @"GetUserPages";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@page", page);

                    SqlParameter outputcountPage = cmd.Parameters.Add("@countPage", SqlDbType.Int);
                    outputcountPage.Direction = ParameterDirection.Output;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new AUser()
                            {
                                idUser = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                MiddleName = reader.GetString(3),
                                Email = reader.GetString(4)
                            });
                        }
                    }
                    countPage = (int)outputcountPage.Value;
                }
            }
            return users;
        }

        public AUser GerUser(int idUser)
        {
            var user = new User();
            if (idUser == -1) return user;

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"select * from Users where idUser=@idUser";
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.idUser = reader.GetInt32(0);
                            user.FirstName = reader.GetString(1);
                            user.LastName = reader.GetString(2);
                            user.MiddleName = reader.GetString(3);
                            user.Email = reader.GetString(4);
                        }
                    }
                }
            }
            return user;

            //return Db.Users.First(u => u.idUser == idUser);
        }

        public bool Save(AUser user)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SaveUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", user.idUser);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    
                    conn.Open();
                    i=cmd.ExecuteNonQuery();
                }
            }
            return i==1;
        }

        public bool Remove(int userId)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"update Users set idState=2 where idUser=@idUser";
                    cmd.Parameters.AddWithValue("@idUser", userId);
                    conn.Open();
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i == 1;
        }

        public IEnumerable<Notice> GetUserNotices(int userId)
        {
            var notices=new List<Notice>();

            using (var con=new SqlConnection(ConnectionString))
            {
                using (var cmd=con.CreateCommand())
                {
                    cmd.CommandText = @"select n.* from UserNotices un
                                        join Notices n on un.idNotice=n.idNotice and n.idState=1 and un.idUser=@userId";
                    cmd.Parameters.AddWithValue("@userId", userId);
                    con.Open();
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notices.Add(new Notice()
                            {
                                idNotice =reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return notices;
        }

        public bool SaveUserNotices(int userId, int noticeId, bool signed)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SaveUserNotices";
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@noticeId", noticeId);
                    cmd.Parameters.AddWithValue("@signed", signed);
                    conn.Open();
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i == 1;
        }
    }
}
