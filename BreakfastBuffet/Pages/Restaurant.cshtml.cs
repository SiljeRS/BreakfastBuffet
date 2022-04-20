using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Models;
using BreakfastBuffet.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BreakfastBuffet.Pages
{
  public class RestaurantModel : PageModel
    {
        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        private readonly MyDbContext _context;
        //CheckInOverview myCheckInOverview = new CheckInOverview();

        public RestaurantModel(MyDbContext context)
        {
            _context = context;
            _myCheckInOverview = new CheckInOverview();
            
        }

        public void OnGet()
        {
            Input = new InputModel();
        }

        public IActionResult OnPost()
        {
            Reservation reservation = new Reservation();

            reservation.RoomNr = Input.RoomNr;
            reservation.NrChildren = Input.NrOfChildren;
            reservation.NrAdults = Input.NrOfAdults;

            var myCheckInOverview = _context.CheckInOverview.Where(p => p.Date.Day == DateTime.Now.Day).FirstOrDefault();
            if(myCheckInOverview == null)
            {
                myCheckInOverview = new CheckInOverview();
                myCheckInOverview.reservationsCheckedIn = new List<Reservation>();
            }

            myCheckInOverview.reservationsCheckedIn.Add(reservation);

            _context.SaveChanges();



            //_context.CheckInOverview.reservationsCheckedIn.Add(reservation);

            //Tilføjer til liste er checkIns
            //myCheckInOverview.reservationsCheckedIn.Add(reservation);


            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage("Success");
        }

        public class InputModel
        {
            //[Required]
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
