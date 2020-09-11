using FormCapture.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormCapture.Shared.DbModels
{
    public class UserSetting : Model
    {
        public string UserID { get; set; }

        public string SettingKey { get; set; }

        public string SettingValue { get; set; }
    }
}