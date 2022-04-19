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

        public RestaurantModel(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Input = new InputModel();
        }

        public IActionResult OnPost()
        {
            var roomCheckIn2 = _context.reservation.Find(Input.RoomNr);

            if(roomCheckIn2 == null)
            {
                Console.WriteLine("Error roomCheckIn");
                //return Page();
            }

            int numberOfChildrenAlreadyCheckedIn = 0;

            //Børn der allerede er checket ind
            foreach (Children chilren in roomCheckIn2.Children)
            {
                if (chilren.CheckedIn == true)
                {
                    numberOfChildrenAlreadyCheckedIn++;
                }
            }

            int numberOfAdultsAlreadyCheckedIn = 0;

            //Børn der allerede er checket ind
            foreach (Adult adults in roomCheckIn2.Adults)
            {
                if (adults.CheckedIn == true)
                {
                    numberOfAdultsAlreadyCheckedIn++;
                }
            }

            //Checkin, if not already checked in
            for (int i = numberOfChildrenAlreadyCheckedIn; i<=Input.NrOfChildren;i++)
            {
                if (roomCheckIn2.Children[i] == null)
                {
                    Console.WriteLine("too many children, already checked in");
                    return Page();
                }
                 roomCheckIn2.Children[i].CheckedIn = true;

  
            }

            //Checkin, if not already checked in
            for (int i = numberOfAdultsAlreadyCheckedIn; i <= Input.NrOfAdults; i++)
            {
                if (roomCheckIn2.Adults[i] == null)
                {
                    Console.WriteLine("too many children, already checked in");
                    return Page();
                }
                roomCheckIn2.Adults[i].CheckedIn = true;

            }

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
            //[Range(0, Double.PositiveInfinity)]
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
