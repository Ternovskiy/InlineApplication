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
        [Key]
        public override int idUser { get; set; }
        [Required]
        public override string FirstName { get; set; }
        [Required]
        public override string LastName { get; set; }
        [Required]
        public override string MiddleName { get; set; }
        [Required]
        public override string Email { get; set; }
    }
}
