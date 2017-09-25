

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Interfaces.Models.Notice
{
   public class Notice
    {
        
        [HiddenInput(DisplayValue = false)]
        public virtual int idNotice { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя подписки")]
        public virtual string Name { get; set; }
    }
}
