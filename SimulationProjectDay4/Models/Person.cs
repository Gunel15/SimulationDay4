using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.Models
{
    public class Person:BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int PositionId {  get; set; }
        public Position? Position { get; set; }
        [MaxLength(20),MinLength(5)]
        public string Description {  get; set; }
        public string ImageUrl {  get; set; }
    }
}
