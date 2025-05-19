using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Persons
{
    public class PersonUpdateVM
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int PositionId { get; set; }
        [MaxLength(20), MinLength(5)]
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
