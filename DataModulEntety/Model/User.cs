﻿using System;
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



        public int idState { get; set; }

        public State State { get; set; }
    }
}
