using System.Text;
using System.Threading.Tasks;
using iCalServer.Models;

namespace iCalServer.Services
{
    public class iCalBuilderService : IiCalBuilderService
    {
        public async Task<string> BuildiCalString(VCalendar calendar)
        {
            string dateFormat = "yyyyMMddTHHmmssZ";
            StringBuilder iCalSB = new StringBuilder();

            iCalSB.AppendLine("BEGIN:VCALENDAR");
            iCalSB.AppendLine("PRODID: -//AJ//ICAL//EN"); 
            iCalSB.AppendLine("VERSION:2.0"); 
            iCalSB.AppendLine("METHOD:PUBLISH"); 
            iCalSB.AppendLine($"X-WR-CALNAME:{calendar.CalendarName}");

            foreach (var ev in calendar.Events)
            {
                iCalSB.AppendLine("BEGIN:VEVENT");
                iCalSB.AppendLine("DESCRIPTION:");
                iCalSB.AppendLine($"UID:{ev.uid}");
                iCalSB.AppendLine($"SEQUENCE:{ev.Sequence}");
                iCalSB.AppendLine($"SUMMARY:{ev.Summary}");
                iCalSB.AppendLine($"DTSTAMP:{ev.dtStamp.ToString(dateFormat)}");
                iCalSB.AppendLine($"DTSTART:{ev.dtStart.ToString(dateFormat)}");
                iCalSB.AppendLine($"DTEND:{ev.dtEnd.ToString(dateFormat)}");
                iCalSB.AppendLine("END:VEVENT");
            }

            iCalSB.AppendLine("END:VCALENDAR");

            return iCalSB.ToString();

        }
    }
}