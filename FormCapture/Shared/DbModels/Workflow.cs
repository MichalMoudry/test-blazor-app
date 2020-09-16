using System;
using System.Collections.Generic;
using System.Text;
using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Workflow : Model
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