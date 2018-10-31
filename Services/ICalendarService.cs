using iCalServer.Models;
using System.Threading.Tasks;

namespace iCalServer.Services
{
    public interface ICalendarService
    {
        Task<VCalendar> GetCalendar(string userId);
    }
}