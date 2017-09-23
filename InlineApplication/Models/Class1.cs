using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InlineApplication.Models
{
    [MetadataType(typeof(ModelViewUser))]
    public abstract partial class AUser
    {

    }

    class ModelViewUser
    {
        [Display(Name = "Имя")]
        public string FirsName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}