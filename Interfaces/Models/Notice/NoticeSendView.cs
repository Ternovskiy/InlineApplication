using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models.Notice
{
    public class NoticeSendView:Notice
    {
        public virtual DateTime DataLastSended { get; set; }
    }
}
