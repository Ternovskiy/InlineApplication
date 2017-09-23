using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModulEntety.Model
{
    public class State
    {

        public   List<User> Users { get; set; }

        [Key]
        public int idState { get; set; }

        public string Name { get; set; }
    }
}
