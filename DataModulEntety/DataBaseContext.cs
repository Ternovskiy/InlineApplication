using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces.Models.Notice;

namespace DataModulEntety
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(string ConStr) : base(ConStr)
        {
            var s = this.States.ToList();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<NoticeEntety> Notices { get; set; }
    }
}
