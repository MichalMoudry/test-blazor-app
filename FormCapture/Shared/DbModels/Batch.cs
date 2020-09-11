using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Batch : CaptureApplicationModel
    {
        public string MetadataID { get; set; }

        /// <summary>
        /// ID of batch creator.
        /// </summary>
        public string UserID { get; set; }
    }
}