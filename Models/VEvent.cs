using System;

namespace iCalServer.Models
{
    public class VEvent
    {
        public string uid { get; set; }
        public DateTimeOffset dtStamp { get; set; }
        public DateTimeOffset dtStart { get; set; }
        public DateTimeOffset dtEnd { get; set; }
        public int Sequence { get; set; }
        public string Summary { get; set; }
    }
}