using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spinning_wheel.Core.Domain
{
    public class SpinningWheel
    {
      
        public string Id { get; set; }
        public string Name { get; set; }
        public HashSet<WheelSegment> Segments { get; set; } = new HashSet<WheelSegment>();
    }
}
