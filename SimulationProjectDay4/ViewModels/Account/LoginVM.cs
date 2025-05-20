using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email or username is required")]
        [MinLength(5)]
        public string UsernameOrEmail {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(32), MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
