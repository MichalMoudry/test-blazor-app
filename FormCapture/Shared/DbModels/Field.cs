using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Field : Model
    {
        public string Name { get; set; }

        public bool IsIdentifying { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Xposition { get; set; }

        public int Yposition { get; set; }

        public string TemplateID { get; set; }

        public string ExpectedValue { get; set; }
    }
}