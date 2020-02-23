
namespace Eve.TapToClick.Utilities
{
    public class TouchpadEventArgs
    {
        public int ContactIndex { get; set; }
        public uint Pressure { get; set; }
        public uint X { get; set; }
        public uint Y { get; set; }
    }
}
