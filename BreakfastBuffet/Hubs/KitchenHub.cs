using Microsoft.AspNetCore.SignalR;

namespace BreakfastBuffet.Hubs
{
    public class KitchenHub : Hub<IKitchen>
    {
        public async Task KitchenInfoUpdate()
        {
            await Clients.All.KitchenInfoUpdate();
        }
    }
}
