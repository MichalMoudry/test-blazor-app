using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    /// <summary>
    /// Class that represents a singular task within the system.
    /// </summary>
    public class WorkflowTask : Model
    {
        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Byte content of the task.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of task's owner.
        /// </summary>
        public string UserID { get; set; }
    }
}