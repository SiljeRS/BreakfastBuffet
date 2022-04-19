using BreakfastBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using BreakfastBuffet.Hubs;

namespace BreakfastBuffet.Pages
{
    public class KitchenModel : PageModel
    {
        private readonly IHubContext<KitchenHub, IKitchen> _kitchenHubContext;
        private readonly MyDbContext _context;

        public KitchenModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> _kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = _kitchenHubContext;
        }

        public void OnGet()
        {
        }
    }
}
