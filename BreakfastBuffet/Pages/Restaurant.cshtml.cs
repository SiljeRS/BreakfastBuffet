using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Models;
using BreakfastBuffet.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using BreakfastBuffet.Hubs;

namespace BreakfastBuffet.Pages
{
  public class RestaurantModel : PageModel
    {
        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        private readonly MyDbContext _context;
        private readonly IHubContext<KitchenHub, IKitchen> _kitchenHubContext;
 

        public RestaurantModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = kitchenHubContext;

        }

        public void OnGet()
        {
            Input = new InputModel();
        }

        public async Task<IActionResult> OnPost()
        {
            Reservation reservation = new Reservation();

            reservation.RoomNr = Input.RoomNr;
            reservation.NrChildren = Input.NrOfChildren;
            reservation.NrAdults = Input.NrOfAdults;

            var myCheckInOverview = _context.CheckInOverview.Where(p => p.Date.Day == DateTime.Now.Day).Include(x => x.reservationsCheckedIn).FirstOrDefault();

            if(myCheckInOverview == null)
            {
                myCheckInOverview = new CheckInOverview();
                myCheckInOverview.reservationsCheckedIn = new List<Reservation>();
                myCheckInOverview.Date = DateTime.Now;
                _context.CheckInOverview.Add(myCheckInOverview);
            }

            myCheckInOverview.reservationsCheckedIn.Add(reservation);

            _context.SaveChanges();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // SIGNALR
            await _kitchenHubContext.Clients.All.KitchenInfoUpdate();


            return RedirectToPage("Succes");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Room number")]
            [Range(0, Double.PositiveInfinity)]
            public int RoomNr { get; set; }

            [Required]
            [Display(Name = "Number of adults")]
            [Range(0, Double.PositiveInfinity)]
            public int NrOfAdults { get; set; }

            [Required]
            [Display(Name = "Number of children")]
            [Range(0, Double.PositiveInfinity)]
            public int NrOfChildren { get; set; }

        }
        
    }
}
