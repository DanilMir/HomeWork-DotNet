using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public record UserProfile(string? FirstName, string? LastName, Gender? Gender, int Age);

    public enum Gender
    {
        Male,
        Female
    }
}