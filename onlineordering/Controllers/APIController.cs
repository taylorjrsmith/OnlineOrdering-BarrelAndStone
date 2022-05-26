using BlazorApp1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlazorApp1.Controllers
{

    [ApiController]
    public class APIController : ControllerBase
    {

        OrderService OrderService { get; set; }

        public APIController(OrderService orderService)
        {
            OrderService = orderService;
        }
        ///api/reports?startDate=2022-01-01&endDate=2022-02-01
        [HttpGet("/api/reports")]
        public ActionResult GetReports([FromQuery] string startDate, [FromQuery] string endDate)
        {
            var startTime = DateTime.ParseExact(startDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact(endDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var reportData = OrderService.GetSalesGroups(startTime, endTime);

            return new JsonResult(new { ReportData = reportData, Image = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/img/icon-bs.png" });
        }
    }
}
