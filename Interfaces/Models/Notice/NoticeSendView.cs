using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models.Notice
{
    public class NoticeSendView:Notice
    {
        [Display(Name = "Дата последней рассылки")]
        public virtual DateTime DataLastSended { get; set; }
    }
}
