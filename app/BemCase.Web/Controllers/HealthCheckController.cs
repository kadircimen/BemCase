using BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Commands.DeleteHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Commands.UpdateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Queries.GetHealthCheckUrlById;
using BemCase.Application.Features.HealthCheckUrls.Queries.GetHealthCheckUrls;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BemCase.Web.Controllers;
[Authorize]
public class HealthCheckController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateHealthCheckUrl([FromBody] CreateHealtCheckUrlRequest request)
    {
        var data = await Mediator.Send(request);
        return Content(JsonConvert.SerializeObject(data));
    }
    [HttpGet]
    public async Task<IActionResult> GetHealthCheckUrlList(int Page, int PageSize)
    {
        var data = await Mediator.Send(new GetHealthCheckUrlListQuery { PageRequest = new PageRequest { Page = Page, PageSize = PageSize } });
        return Content(JsonConvert.SerializeObject(data));
    }
    [HttpGet]
    public async Task<IActionResult> GetHealthCheckUrlById(int Id)
    {
        var data = await Mediator.Send(new GetHealthCheckUrlByIdQuery { Id = Id });
        return Content(JsonConvert.SerializeObject(data));
    }
    [HttpPost]
    public async Task<IActionResult> UpdateHealthCheckUrl([FromBody] UpdateHealthCheckUrlRequest request)
    {
        var data = await Mediator.Send(request);
        return Content(JsonConvert.SerializeObject(data));
    }
    [HttpPost]
    public async Task<IActionResult> DeleteHealthCheckUrl([FromBody] DeleteHealthCheckUrlCommand request)
    {
        var data = await Mediator.Send(request);
        return Content(JsonConvert.SerializeObject(data));
    }
}
