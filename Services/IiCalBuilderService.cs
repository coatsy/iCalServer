using System.Threading.Tasks;
using iCalServer.Models;

namespace iCalServer.Services
{
    public interface IiCalBuilderService
    {
        Task<string> BuildiCalString(VCalendar calendar);
    }
}