using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

    public  partial class AUser : IUser
    {

        public virtual int idUser { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Email { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName.Substring(0, 1)}.{MiddleName.Substring(0,1)}.";
        }
    }
    

    #endregion

    #region Мета данные

    [MetadataType(typeof(ModelViewUser))]
    public  partial class AUser
    {

    }

    class ModelViewUser
    {

        //[Key]
        [HiddenInput(DisplayValue = false)]
        public int idUser { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Введите адрес почты")]
        [EmailAddress(ErrorMessage = "Не корректный адрес почты")]
        public string Email { get; set; }

    }

    #endregion

}
