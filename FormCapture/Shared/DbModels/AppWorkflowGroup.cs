using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// AppWorkflowGroup class represents group of tasks.
    /// </summary>
    public class AppWorkflowGroup : Model
    {
        /// <summary>
        /// ID of the application workflow that this group belongs to.
        /// </summary>
        public string AppWorkflowID { get; set; }

        /// <summary>
        /// Name of the task group. Ex.: Scan, Export, ...
        /// </summary>
        public string WorkflowGroupName { get; set; }
    }
}