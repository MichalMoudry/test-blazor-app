using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Class that represents a singular task within a system.
    /// </summary>
    public class AppWorkflowTask : Model
    {
        /// <summary>
        /// Name of the task.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Byte content of the task.
        /// </summary>
        public byte[] TaskContent { get; set; }

        /// <summary>
        /// ID of task's owner.
        /// </summary>
        public string UserID { get; set; }
    }
}