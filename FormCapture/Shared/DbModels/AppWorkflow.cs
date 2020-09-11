using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    public class AppWorkflow : Model
    {
        /// <summary>
        /// Name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of app's owner.
        /// </summary>
        public string UserID { get; set; }
    }
}