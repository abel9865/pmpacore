
namespace Domain
{
    public class SystemTimeZoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrentUtcOffset { get; set; }
        public bool IsCurrentlyDst { get; set; }
    }
}
