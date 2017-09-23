using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;

namespace DataModulEntety
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(string ConStr) : base(ConStr) { }


        public DbSet<User> Users { get; set; }

    }
}
