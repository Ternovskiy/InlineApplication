

namespace DataModul.Models
{

    public abstract partial class User:IUser
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        
    }


    interface IUser
    {
        string FirsName { get; set; }
    }


    //[MetadataType(typeof(ModelViewUser))]
    //public partial class User
    //{
    //    public string FirsName { get; set; }
    //    public string LastName { get; set; }
    //    public string MiddleName { get; set; }
    //    public string Email { get; set; }
    //}

    //class ModelViewUser
    //{
    //    [Display(Name = "Имя")]
    //    public string FirsName { get; set; }
    //    [Display(Name = "Фамилия")]
    //    public string LastName { get; set; }
    //    [Display(Name = "Отчество")]
    //    public string MiddleName { get; set; }
    //    [Display(Name = "E-mail")]
    //    public string Email { get; set; }

    //}
}
