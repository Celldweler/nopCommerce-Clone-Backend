using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers.Testing
{
    public class TestController : ApiBaseController
    {
        [HttpGet]
        public string Get() => "test controller is work!";
    }
}
