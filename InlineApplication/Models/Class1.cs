using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Interfaces.Models.Notice;

namespace InlineApplication.Models
{
    public class ViewUserNotice
    {
        public Notice Notice { get; set; }
        public bool Signed { get; set; }
    }
}