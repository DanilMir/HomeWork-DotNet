using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserProfile
    {
        //[Display(Name = "Имя")]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия"), StringLength(10)]
        public string Surname { get; set; }
        [Display(Name = "Возраст"), Range(0, 100, ErrorMessage = "Age has to be between 0 and 100")]
        public int? Age { get; set; }
        [Display(Name = "Пол")]
        public Gender Sex { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Муж")]
        Male,
        [Display(Name = "Жен")]
        Female
    }
}