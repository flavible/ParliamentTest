using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonsDomain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParliamentServices;

namespace CommonsAPI.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        // GET api/events
        [HttpGet]
        public ActionResult<string> Get()
        {
            CalendarService calendarService = new CalendarService();
            EventList eventList = calendarService.GetEvents();
            return JsonConvert.SerializeObject(eventList.eventList);
        }

        // GET api/eventes/2019-06-03/2019-06-09
        [HttpGet("{from}/{to}")]
        public ActionResult<string> Get(string from, string to)
        {
            CalendarService calendarService = new CalendarService();
            EventList eventList = calendarService.GetEvents(from, to);
            return JsonConvert.SerializeObject(eventList.eventList);
        }

    }
}
