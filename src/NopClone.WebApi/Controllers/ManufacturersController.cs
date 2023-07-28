using Microsoft.AspNetCore.Mvc;
using NopClone.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    public class ManufacturersController : ApiBaseController
    {
        private NopCloneDataContext _ctx;

        public ManufacturersController(NopCloneDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ctx.Manufacturers.ToList());
        }
    }
}
