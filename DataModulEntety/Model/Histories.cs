using System;
using System.ComponentModel.DataAnnotations;

namespace DataModulEntety.Model
{
    public class Histories
    {
        [Key]
        public int idHistory { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int idNotice { get; set; }
        public int idUser { get; set; }
        public int idState { get; set; }

        public virtual NoticeEntety Notices { get; set; }
        public virtual State States { get; set; }
        public virtual User Users { get; set; }
    }
}