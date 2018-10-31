using System.Threading.Tasks;
using System.Collections.Generic;
using iCalServer.Models;
using System;

namespace iCalServer.Services 
{
    public class MockCalendarService : ICalendarService
    {
        private Dictionary<string, CalStore> userCals = new Dictionary<string, CalStore>(); 

        private Random rnd = new Random();

        public async Task<VCalendar> GetCalendar(string userId)
        {
            if (! userCals.ContainsKey(userId))
            {
                userCals[userId] = new CalStore() { TimesCalled = 1, Calendar = BuildCalendar(userId) };
            }
            else
            {
                userCals[userId].TimesCalled++;
                updateCalendar(userCals[userId]);
            }

            return userCals[userId].Calendar;
        }

        private void updateCalendar(CalStore calStore)
        {
            // move some of the events around and update the sequences
            foreach (var ev in calStore.Calendar.Events)
            {
                double nextNum = rnd.NextDouble();
                if (nextNum > 0.6d)
                {
                    // update the sequence because we're changing this event
                    ev.Sequence = calStore.TimesCalled;
                    ev.dtStart.AddHours(1);
                    ev.dtEnd.AddHours(1);
                }
            }
        }

        private VCalendar BuildCalendar(string userId)
        {
            VCalendar vCal = new VCalendar();
            vCal.CalendarName = $"Internet Calendar for {userId}";

            vCal.Events = new List<VEvent>();

            for (int i = 0; i < 5; i++)
            {
                VEvent ev = new VEvent();
                ev.uid = Guid.NewGuid().ToString();
                ev.Sequence = 0;
                ev.dtStamp = DateTimeOffset.UtcNow;
                ev.dtStart = DateTimeOffset.UtcNow.AddDays(i).AddHours(rnd.Next(-4, 5));
                ev.dtEnd = ev.dtStart.AddMinutes(15 * rnd.Next(1, 9));
                ev.Summary = $"Event number {i}";

                vCal.Events.Add(ev);
            }


            return vCal;
        }
    }

    class CalStore
    {
        public int TimesCalled { get; set; }
        public VCalendar Calendar { get; set; }
    }
}