using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using iCalServer.Services;
using iCalServer.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace iCalServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService calenderService;
        private readonly IiCalBuilderService builderService;

        public CalendarController(ICalendarService calSvc, IiCalBuilderService bldSvc)
        {
            calenderService = calSvc;
            builderService = bldSvc;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetICal()
        {
            return await GetICal(User.Identity.Name);
        }

        [HttpGet("{userId}")]
        [Authorize(AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetICal(string userId)
        {
            return await builderService.BuildiCalString(await calenderService.GetCalendar(userId));
        }
    }
}