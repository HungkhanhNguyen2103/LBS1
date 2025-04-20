using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class FcmMessageModel
    {
        public string to { get; set; }  
        public NotificationModel notification { get; set; }
    }

    public class NotificationModel
    {
        public string title { get; set; }
        public string body { get; set; }
    }
}
