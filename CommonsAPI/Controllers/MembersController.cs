using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonsDomain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParliamentServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommonsAPI.Controllers
{
    [Route("api/members")]
    public class MemberController : Controller
    {

        // GET api/members/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            MemberService memberService = new MemberService();
            Member member = memberService.GetMember(id);
            return JsonConvert.SerializeObject(member);
        }
    }
}
