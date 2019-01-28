using Microsoft.AspNetCore.Mvc;

namespace Workshop.Api.Controllers
{
    /// <summary>
    ///     Base controller implementation for all api endpoints
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class WorkshopBaseController : Controller
    {
    }
}