using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Queue class represents queue of processed batches.
    /// </summary>
    public class Queue : CaptureApplicationModel
    {
        /// <summary>
        /// ID of a group of tasks that will be executed next.
        /// </summary>
        public string AppWorkflowTaskGroupID { get; set; }

        /// <summary>
        /// ID of a user that started the queue.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Status of the specific queue.
        /// </summary>
        public string Status { get; set; }
    }
}