﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Models;

namespace DataModul.Models
{
    
    public partial class User:  AUser
    {
        //public int Id { get; set; }
        //public string FirsName { get; set; }
        //public string LastName { get; set; }
        //public string MiddleName { get; set; }
        //public string Email { get; set; }
        public override int idUser { get; set; }

        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string MiddleName { get; set; }
        public override string Email { get; set; }
    }
}
