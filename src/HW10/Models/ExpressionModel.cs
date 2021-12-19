using System.ComponentModel.DataAnnotations;

namespace HW10.Models
{
    public class ExpressionModel
    {
        [Key]
        public string Expression { get; set; }
        [Required]
        public int Value { get; set; }
    }
}