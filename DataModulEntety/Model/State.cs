using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModulEntety.Model
{
    public class State
    {
        public State()
        {
            Users=new HashSet<User>();
            Notices=new HashSet<NoticeEntety>();
            Histories=new HashSet<Histories>();
        }

        [Key]
        public int idState { get; set; }
        public string Name { get; set; }


        public virtual  ICollection<User> Users { get; set; }
        public virtual ICollection<NoticeEntety> Notices { get; set; }
        public virtual ICollection<Histories> Histories { get; set; }
    }
}
