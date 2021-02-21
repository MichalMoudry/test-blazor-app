using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Instances of this class represents M:N association between CaptureApplication class and AppWorkflow class.
    /// </summary>
    public class CaptureAppWorkflows : CaptureApplicationModel
    {
        /// <summary>
        /// ID of the workflow.
        /// </summary>
        public string WorkflowID { get; set; }

        public string WorkflowName { get; set; }
    }
}