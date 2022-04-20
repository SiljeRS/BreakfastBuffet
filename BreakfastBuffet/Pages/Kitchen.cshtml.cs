
using BreakfastBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using BreakfastBuffet.Hubs;
using System.ComponentModel.DataAnnotations;

namespace BreakfastBuffet.Pages
{
    public class KitchenModel : PageModel
    {
        /* 
        private readonly IHubContext<KitchenHub, IKitchen> _kitchenHubContext;
        private readonly MyDbContext _context;

        public int _amountOfAdults;
        public int _amountOfChildren;

        public KitchenModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> _kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = _kitchenHubContext;
        }

        public void OnGet()
        {
            var _amountOfAdult = _context.Breakfast.Where(p => p.Date.Day == DateTime.Now.Day).FirstOrDefault();
            _amountOfChildren;
        }

        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required]
            public DateTime Date { get; set; }

            
        }
        */
    }
}