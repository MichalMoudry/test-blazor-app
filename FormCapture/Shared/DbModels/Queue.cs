using FormCapture.Shared.Util;
using FormCapture.Shared.Util.Enums;

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
        public TaskGroupID AppWorkflowTaskGroupID { get; set; }

        /// <summary>
        /// Status of the specific queue.
        /// </summary>
        public QueueStatus Status { get; set; }

        /// <summary>
        /// ID of a user that started the queue.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// ID of the workflow.
        /// </summary>
        public string WorkflowID { get; set; }
    }
}