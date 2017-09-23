using System.ComponentModel.DataAnnotations;

namespace Interfaces.Models
{

    #region Интерфейс

    interface IUser
    {

        int idUser { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Email { get; set; }
    }

    #endregion

    #region Модель

    public abstract partial class AUser : IUser
    {

        public virtual int idUser { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Email { get; set; }
    }
    

    #endregion

    #region Мета данные

    [MetadataType(typeof(ModelViewUser))]
    public abstract partial class AUser
    {

    }

    class ModelViewUser
    {

        //[Key]
        //public int idUser { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }

    #endregion

}
