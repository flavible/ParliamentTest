using System;
using System.Collections.Generic;

namespace CommonsDomain
{
    //placeholder class
    public class EventList
    {
        public List<Event> eventList = new List<Event>();

        public void addEvent(Event calendarEvent){
            eventList.Add(calendarEvent);
        }
        public int getEventCount() {
            return eventList.Count;
        }
    }
}
