using Microsoft.AspNetCore.SignalR;

namespace BreakfastBuffet.Hubs
{
    public class KitchenHub : Hub<IKitchen>
    {
        public async Task KitchenInfoUpdate()
        {
            //Gør noget herawait Clients.All.ExpenseUpdate(expense);
        }
    }
}
