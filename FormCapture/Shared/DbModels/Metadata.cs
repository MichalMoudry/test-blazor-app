using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Metadata : Model
    {
        public string EntityID { get; set; }

        public string DataKey { get; set; }

        public string DataValue { get; set; }
    }
}