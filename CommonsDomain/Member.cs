using System;

namespace CommonsDomain
{
    public class Member
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string listAs { get; set; }
        public string fullTitle { get; set; }
        public DateTime? dob { get; set; }
        public string gender { get; set; }
        public string party { get; set; }
        public string house { get; set; }
        public string memberFrom { get; set; }
        public DateTime? houseStart { get; set; }

        public Member(string id, string displayName) {
            this.displayName = displayName;
            this.id = id;
        }

        public Member(string id, string displayName, string listAs,
             string fullTitle, DateTime? dob, string gender, string party, 
             string house, string memberFrom, DateTime? houseStart) {

            this.id = id;
            this.displayName = displayName;
            this.listAs = listAs;
            this.fullTitle = fullTitle;
            this.dob = dob;
            this.gender = gender;
            this.party = party;
            this.house = house;
            this.memberFrom = memberFrom;
            this.houseStart = houseStart;
        }
    }


}
