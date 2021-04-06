using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class UserApps : Model
    {
        public string UserID { get; set; }

        public string ApplicationID { get; set; }

        public string ApplicationName { get; set; }
    }
}