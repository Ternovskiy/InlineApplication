using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Interfaces.Models.Notice;

namespace DataModulEntety.Model
{
    [Table("Notices")]
    public class NoticeEntety:Notice
    {
        public NoticeEntety()
        {
            
        }

        public NoticeEntety(Notice notice)
        {
            idNotice = notice.idNotice;
            Name = notice.Name;
            idState = 1;
        }
        [Key]
        public override int idNotice { get; set; }


        public int idState { get; set; }

        public List<User> Users { get; set; }
    }
}