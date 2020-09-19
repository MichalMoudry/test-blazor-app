using System;
using System.Collections.Generic;
using System.Text;
using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class WorkflowTaskGrouping : Model
    {
        public string TaskID { get; set; }

        public string TaskGroupName { get; set; }

        public string WorkflowID { get; set; }

        public int ExecutionOrderNumber { get; set; }
    }
}