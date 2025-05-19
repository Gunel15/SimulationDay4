using Microsoft.AspNetCore.Identity;

namespace SimulationProjectDay4.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public string ImageUrl { get; set; } = "default.jpg";
    }
}
