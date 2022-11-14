using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spinning_wheel.Core.Domain
{
    public class WheelSegment
    {
    
        public string Id { get; set; }
        public string Label { get; set; }
        public string Reward { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string? Image { get; set; }
        public string SpinningWheelId { get; set; }
        public SpinningWheel SpinningWheel { get; set; }
    }
}
