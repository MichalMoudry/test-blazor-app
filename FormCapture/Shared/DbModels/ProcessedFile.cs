using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Class that represents a single file that is processed by the system.
    /// </summary>
    public class ProcessedFile : Model
    {
        /// <summary>
        /// Name of the processed file. Ex.: File.pdf
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Content of the file.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// File type of the processed file.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ID of the batch that this file belongs to.
        /// </summary>
        public string BatchID { get; set; }
    }
}