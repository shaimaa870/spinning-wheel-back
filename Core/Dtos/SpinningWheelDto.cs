namespace spinning_wheel.Core.Dtos
{
    public class SpinningWheelDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public List<WheelSegmentDto> Segments { get; set; } = new List<WheelSegmentDto>();
    }
    public class WheelSegmentDto
    {
        public string? Id { get; set; }
        public string Label { get; set; }
        public string Reward { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string? SpinningWheelId { get; set; }
    }
}
