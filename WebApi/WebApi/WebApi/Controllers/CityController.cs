using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    //Tüm Origin,tüm headers ve tüm metodlar için.
    [EnableCors("*","*","*")]
    public class CityController : ApiController
    {
        private string[] sehirler = new string[] { "aa", "bb", "vv" };
        public string[] Get()
        {
            return new string[] { "aa", "bb", "vv" };
        }
        public string Get(int id)
        {
            return sehirler[id];
        }
    }
}
