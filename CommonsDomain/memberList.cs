using System;
using System.Collections.Generic;

namespace CommonsDomain
{
    //placeholder class
    public class MemberList
    {
        public List<Member> memberList = new List<Member>();

        public void AddMember(Member member){
            memberList.Add(member);
        }
        public int GetMemberCount() {
            return memberList.Count;
        }
    }
}
