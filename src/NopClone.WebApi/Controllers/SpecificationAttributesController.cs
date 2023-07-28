using Microsoft.AspNetCore.Mvc;
using NopClone.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    public class SpecificationAttributesController : ApiBaseController
    {
        private NopCloneDataContext _ctx;

        public SpecificationAttributesController(NopCloneDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var specificationAttributes = _ctx.SpecificationAttributes.ToList();

            return Ok(specificationAttributes);
        }
    }
}
