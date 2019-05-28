using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Fornavn")]
        public string Fornavn { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string Efternavn { get; set; }

        [Required]
        [Display(Name = "DBF")]
        [Range(10000,99999, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public int DBF { get; set; }

        [Required]
        [Display(Name = "Adresse linje 1")]
        public string Adresse1 { get; set; }

        [Display(Name = "Adresse linje 2")]
        public string Adresse2 { get; set; }

        [Required]
        [Display(Name = "Postnummer")]
        public string Postnummer { get; set; }

        [Required]
        [Display(Name = "By")]
        public string By { get; set; }
    }
}