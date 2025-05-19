using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Account
{
    public class RegisterVM
    {
        [MaxLength(32),MinLength(4)]
        public string FullName {  get; set; }
        [MaxLength(32), MinLength(4)]
        public string Username {  get; set; }
        [MaxLength(32), MinLength(4),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(32), MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(32), MinLength(4), DataType(DataType.Password),Compare(nameof(Password))]
        public string RepeatPassword {  get; set; }
    }
}
