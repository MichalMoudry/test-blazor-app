using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Template : CaptureApplicationModel
    {
        public byte[] Image { get; set; }

        public int Xdimension { get; set; }

        public int Ydimension { get; set; }
    }
}