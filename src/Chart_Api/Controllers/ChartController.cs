using Chart_Api.DataStorage;
using Chart_Api.Hubs;
using Chart_Api.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;

namespace Chart_Api.Controllers
{
    [Route("api/{controller}")]
    public class ChartController: ControllerBase
    {
        private IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            return Ok(new {Message = "Request Completed"});
        }
    }
}
