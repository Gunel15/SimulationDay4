using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.Models
{
    public class Position:BaseEntity
    {
        [MaxLength(20)]
        public string Name {  get; set; }
        public IEnumerable<Person> Persons {  get; set; }
    }
}
