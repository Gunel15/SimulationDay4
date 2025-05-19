using Microsoft.EntityFrameworkCore;
using SimulationProjectDay4.Models;

namespace SimulationProjectDay4.DataAccessLayer
{
    public class MosaicDbContext:DbContext
    {
        public MosaicDbContext(DbContextOptions opt):base(opt) 
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
