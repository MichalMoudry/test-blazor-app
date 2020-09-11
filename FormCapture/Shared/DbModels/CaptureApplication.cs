using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Instances of this class represent a capture application.
    /// </summary>
    public class CaptureApplication : Model
    {
        /// <summary>
        /// Name of the application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of app's owner.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Locale of app that will be used when capturing data.
        /// </summary>
        public string Locale { get; set; }
    }
}