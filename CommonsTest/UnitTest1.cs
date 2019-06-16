using System;
using CommonsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParliamentServices;

namespace CommonsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalenderAddEvent()
        {
            System.Console.WriteLine("Testing Calendar Add Event");
            EventList eventList = new EventList();
            eventList.addEvent(new Event(DateTime.Today, DateTime.Today, "", "", "", 1, 
                "", "", "", true));
            Assert.AreNotEqual(0, eventList.getEventCount());
        }

        [TestMethod]
        public void TestCalenderRequestCount()
        {
            System.Console.WriteLine("Testing Calendar Request Count");
            CalendarService calanderService = new CalendarService();
            EventList eventList = calanderService.GetEvents();
            Assert.AreNotEqual(0, eventList.getEventCount());
        }

        [TestMethod]
        public void TestMemberRequest()
        {
            System.Console.WriteLine("Testing Member Request");
            MemberService memberService = new MemberService();
            Member member = memberService.GetMember("2");
            Assert.AreEqual("Kelvin Hopkins", member.displayName);
        }

    }
}
