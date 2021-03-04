using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Class that represents a single file that is processed by the system.
    /// </summary>
    public class ProcessedFile : Model
    {
        /// <summary>
        /// Content of the file.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Name of the processed file. Ex.: File.pdf
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the queue that this file belongs to.
        /// </summary>
        public string QueueID { get; set; }

        /// <summary>
        /// ID of the template that this file belongs to.
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// File type of the processed file.
        /// </summary>
        public string Type { get; set; }
    }
}