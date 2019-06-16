using System;
using System.Collections.Generic;

namespace CommonsDomain
{
    public class Event
    {
        public string id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string description { get; set; }
        public int sortOrder { get; set; }
        //Type & House basically useless for now, but will be useful to expand from current goals
        public string type { get; set; }
        public string house { get; set; }
        public string category { get; set; }
        public Boolean hasSpeaker { get; set; }
        //Placeholder for committee addition
        public Committee committee { get; set; }
        //Placeholder for search by tag addition
        public List<string> tags { get; set; }
        public MemberList memberList = new MemberList();

        public Event(string id, DateTime startDate, DateTime endDate, string startTime,
            string endTime, string description, int sortOrder, string type, 
            string house, string category, Boolean hasSpeaker) {

            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.description = description;
            this.sortOrder = sortOrder;
            this.type = type;
            this.house = house;
            this.category = category;
            this.hasSpeaker = hasSpeaker;
        }

        public void AddMember(Member member) {
            memberList.AddMember(member);
        }

        public int getMemberCount()
        {
            return memberList.GetMemberCount();
        }
    }
}
