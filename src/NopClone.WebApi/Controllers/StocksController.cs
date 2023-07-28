using Microsoft.AspNetCore.Mvc;
using NopClone.Data.Context;

namespace NopClone.WebApi.Controllers;

[Microsoft.AspNetCore.Components.Route("api/stocks")]
public class StocksController : ApiBaseController
{
    private readonly NopCloneDataContext _ctx;

    public StocksController(NopCloneDataContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}