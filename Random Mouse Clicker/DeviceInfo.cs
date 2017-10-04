using System.Drawing;

namespace Random_Mouse_Clicker
{
    public class DeviceInfo
    {
        public string DeviceName { get; set; }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
        public Rectangle MonitorArea { get; set; }
    }
}
