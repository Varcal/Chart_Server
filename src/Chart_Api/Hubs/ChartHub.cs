using System.Collections.Generic;
using System.Threading.Tasks;
using Chart_Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chart_Api.Hubs
{
    public class ChartHub: Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
