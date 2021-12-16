using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserProfile
    {
        [Required (ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Required (ErrorMessage = "Не указана фамилия")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Required (ErrorMessage = "Не указан возраст")]
        [Range(1, 510, ErrorMessage = "Недопустимый возраст")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        
        [Display(Name = "Пол")]
        public Gender Sex { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}