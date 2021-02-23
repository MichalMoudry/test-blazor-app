using System;
using System.Collections.Generic;
using System.Text;
using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class WorkflowTaskParameter : Model
    {
        public string ParameterName { get; set; }

        public string ParemeterValue { get; set; }

        public string TaskID { get; set; }
    }
}