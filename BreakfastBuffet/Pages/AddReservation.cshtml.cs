using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Data;
using BreakfastBuffet.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using BreakfastBuffet.Hubs;

namespace BreakfastBuffet.Pages
{
    public class AddReservationModel : PageModel
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<KitchenHub, IKitchen> _kitchenHubContext;
        public AddReservationModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = kitchenHubContext;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost()
        {

            var tempBreakfast = _context.Breakfast.Where(x => x.Date == Input.Date).FirstOrDefault();
            if (tempBreakfast != null)
            {
                tempBreakfast.NChildren = Input.Children;
                tempBreakfast.NAdults = Input.Adults;
            }
            else
            {
                Breakfast breakfast = new Breakfast();

                breakfast.Date = Input.Date;
                if (Input.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Input.Date", "Date must be in the future");
                    return Page();
                }

                breakfast.NChildren = Input.Children;
                breakfast.NAdults = Input.Adults;

                _context.Breakfast.Add(breakfast);
            }

            
            await _context.SaveChangesAsync();

            await _kitchenHubContext.Clients.All.KitchenInfoUpdate();

            return RedirectToPage("Reception");
            
        }
        
        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required]
            public DateTime Date { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers above 0 allowed")]
            public int Adults { get; set; }

            [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
            public int Children { get; set; }
        }
    }
}

