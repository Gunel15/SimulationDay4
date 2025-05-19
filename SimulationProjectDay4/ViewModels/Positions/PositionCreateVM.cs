using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Positions
{
    public class PositionCreateVM
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
