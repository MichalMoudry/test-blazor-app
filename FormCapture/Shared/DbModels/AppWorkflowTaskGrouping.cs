using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    public class AppWorkflowTaskGrouping : Model
    {
        public string AppWorkflowTaskID { get; set; }

        public string AppWorkflowTaskGroupID { get; set; }
    }
}