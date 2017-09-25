using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public State State { get; set; }

        public List<NoticeEntety> Notices { get; set; }
    }
}
