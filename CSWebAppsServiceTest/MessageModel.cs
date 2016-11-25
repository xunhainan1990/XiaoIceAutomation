using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWebAppsServiceTest
{
    public class MessageModel
        {
            public string UserId { get; set; }
            public string UserNickname { get; set; }
            public string StaffId { get; set; }
            public string Content { get; set; }
            public MessageImage Image { get; set; }
            public int ContentType { get; set; }
            public int DirectionType { get; set; }
            public int CreateTimeStamp { get; set; }
            public string CreateTime { get; set; }
            public int PromisedTag { get; set; }
        }
    public class MessageImage
    {
        public MessageImage()
        {
            Url = "";
            Height = "";
            Width = "";
        }

        public string Url { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }

    }
}
