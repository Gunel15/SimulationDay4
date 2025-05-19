using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Persons
{
    public class PersonGetVM
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public string PositionName { get; set; }
        [MaxLength(20), MinLength(5)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
