using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimulationProjectDay4.Models;

namespace SimulationProjectDay4.DataAccessLayer
{
    public class MosaicDbContext:IdentityDbContext<User,Role,Guid>
    {
        public MosaicDbContext(DbContextOptions opt):base(opt) 
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
