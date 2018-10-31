using System.Collections.Generic;

namespace iCalServer.Models
{
    public class VCalendar
    {
        public string CalendarName { get; set; }
        public List<VEvent> Events { get; set; }

    }
}