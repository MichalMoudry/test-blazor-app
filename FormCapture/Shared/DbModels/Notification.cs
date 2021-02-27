using FormCapture.Shared.Util;
using FormCapture.Shared.Util.Enums;

namespace FormCapture.Shared.DbModels
{
    public class Notification : Model
    {
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string RecipientID { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}