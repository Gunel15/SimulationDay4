using System.ComponentModel.DataAnnotations;

namespace SimulationProjectDay4.ViewModels.Positions
{
    public class PositionGetVM
    {
        public int Id {  get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
