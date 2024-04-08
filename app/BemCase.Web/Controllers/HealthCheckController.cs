using BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Queries.GetHealthCheckUrls;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BemCase.Web.Controllers;
public class HealthCheckController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateHealthCheckUrl([FromBody] CreateHealtCheckUrlRequest request)
    {
        var data = await Mediator.Send(request);
        return Content(JsonConvert.SerializeObject(data));
    }
    public async Task<IActionResult> GetHealthCheckUrlList(int Page, int PageSize)
    {
        var data = await Mediator.Send(new GetHealthCheckUrlListQuery { PageRequest = new PageRequest { Page = Page, PageSize = PageSize } });
        return Content(JsonConvert.SerializeObject(data));
    }
}
