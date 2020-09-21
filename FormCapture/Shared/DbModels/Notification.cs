using FormCapture.Shared.Util;

namespace FormCapture.Shared.DbModels
{
    public class Notification : Model
    {
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string RecipientID { get; set; }

        public string NotificationType { get; set; }
    }
}