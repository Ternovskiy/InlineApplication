using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Models;

namespace DataModulEntety.Model
{
    public class User  :AUser
    {
        public User()
        {
            this.Notices = new HashSet<NoticeEntety>();
        }

        public User(AUser user)
        {
            idUser = user.idUser;
            FirstName= user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            Email = user.Email;
            idState = 1;
        }

        [Key]
        public override int idUser { get; set; }
        public int idState { get; set; }


        public virtual State State { get; set; }
        public virtual ICollection<NoticeEntety> Notices { get; set; }
    }
}
