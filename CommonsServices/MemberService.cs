using System;
using System.Xml;
using System.IO;
using CommonsDomain;
using System.Net;

namespace ParliamentServices
{
    public class MemberService : ParliamentService {
        private DateTime today = DateTime.Today;

        public MemberService()
        {
            this.URI = "http://data.parliament.uk";
        }

        public Member GetMember(string id) {
            XmlDocument xml = GetXMLFromURI("/membersdataplatform/services/mnis/members/query/id="+id+"/");
            return CreateMember(xml);
        }


        private Member CreateMember(XmlDocument xml) {
            //todo convert hard-coded filter to perameterised filter using array of tuples
            XmlNodeList nl = xml.SelectNodes("Members");
            XmlNode root = nl[0];

            foreach (XmlNode xnode in root.ChildNodes)
            {
                if (xnode.Name == "Member")
                {
                    string id = GetXmlAttribute(xnode, "Member_Id");
                    string displayAs = GetXmlValue(xnode, "DisplayAs");
                    string listAs = GetXmlValue(xnode, "ListAs");
                    string fullTitle = GetXmlValue(xnode, "FullTitle");
                    DateTime dob = Convert.ToDateTime(GetXmlValue(xnode, "DateOfBirth"));
                    string gender = GetXmlValue(xnode, "Gender");
                    string party = GetXmlValue(xnode, "Party");
                    string house = GetXmlValue(xnode, "House");
                    string memberFrom = GetXmlValue(xnode, "MemberFrom");
                    DateTime houseStart = Convert.ToDateTime(GetXmlValue(xnode, "HouseStartDate"));
                    return new Member(id, displayAs, listAs, fullTitle, dob, 
                        gender, party, house, memberFrom, houseStart);
                }
            }
            return null;
        }
    }
}
