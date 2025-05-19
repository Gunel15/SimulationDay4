using Microsoft.AspNetCore.Identity;

namespace SimulationProjectDay4.Models
{
    public class Role:IdentityRole<Guid>
    {
        public Role()
        {
            
        }

        public Role(string name):base(name) 
        {
            
        }
    }
}
