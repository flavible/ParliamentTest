using System;
using System.Xml;
using System.IO;
using CommonsDomain;
using System.Net;

namespace ParliamentServices
{
    public class CalendarService : ParliamentService {
        private DateTime today = DateTime.Today;

        public CalendarService() {
            this.URI = "http://service.calendar.parliament.uk";
        }

        public EventList GetEvents(string from, string to) {
            XmlDocument xml = GetXMLFromURI($"/calendar/events/list.xml?startdate={from}&enddate={to}");
            return CreateCalendar(xml);
        }

        public EventList GetEvents()
        {
            string from = GetPreviousWeekday(today, DayOfWeek.Monday).ToString("yyyy-MM-dd");
            string to = GetNextWeekday(today, DayOfWeek.Sunday).ToString("yyyy-MM-dd");
            XmlDocument xml = GetXMLFromURI($"/calendar/events/list.xml?startdate={from}&enddate={to}");
            return CreateCalendar(xml);

        }

        private static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private static DateTime GetPreviousWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek - 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private EventList CreateCalendar(XmlDocument xml) {
            EventList eventList = new EventList();
            //todo convert hard-coded filter to perameterised filter using array of tuples
            XmlNodeList nl = xml.SelectNodes("ArrayOfEvent");
            XmlNode root = nl[0];

            foreach (XmlNode xnode in root.ChildNodes)
            {
                string type = GetXmlValue(xnode, "Type");
                string house = GetXmlValue(xnode, "House");
                if (type == "Main Chamber" && house == "Commons") {
                    DateTime startDate = Convert.ToDateTime(GetXmlValue(xnode,"StartDate")).Date;
                    DateTime endDate = Convert.ToDateTime(GetXmlValue(xnode, "EndDate")).Date;
                    string startTime = GetXmlValue(xnode, "StartTime");
                    string endTime = GetXmlValue(xnode, "EndTime");
                    string description = GetXmlValue(xnode, "Description");
                    int sortOrder = Convert.ToInt16(GetXmlValue(xnode, "SortOrder"));
                    string category = GetXmlValue(xnode, "Category");
                    Boolean hasSpeaker = Convert.ToBoolean(GetXmlValue(xnode, "HasSpeakers"));
                    string eventId = GetXmlAttribute(xnode, "Id");
                    Event calendarEvent = new Event(eventId, startDate, endDate, startTime,
                        endTime, description, sortOrder, type, house, category, hasSpeaker);
                    //todo Running out of time, but this should be in seperate function
                    XmlNode mRoot = xnode.SelectNodes("Members")[0];
                    foreach( XmlNode mNode in mRoot.ChildNodes) {
                        string id = GetXmlAttribute(mNode, "Id");
                        string displayName = GetXmlValue(mNode, "Name");
                        calendarEvent.AddMember(new Member(id, displayName));
                    }
                    eventList.addEvent(calendarEvent);
                }
            }
            return eventList;
        }
    }
}
