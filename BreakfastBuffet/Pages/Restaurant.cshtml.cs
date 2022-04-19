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
            var roomCheckIn2 = _context.Reservation.Find(Input.RoomNr);

            if(roomCheckIn2 == null)
            {
                Console.WriteLine("Error with room CheckIn");
                return RedirectToPage("Error");
            }

            //**************Children************************//
            int numberOfChildrenAlreadyCheckedIn = 0;

            foreach (Child chilren in roomCheckIn2.Children)
            {
                if (chilren.CheckedIn == true)
                {
                    numberOfChildrenAlreadyCheckedIn++;
                }
            }

            for (int i = numberOfChildrenAlreadyCheckedIn; i<=Input.NrOfChildren;i++)
            {
                if (roomCheckIn2.Children[i] == null)
                {
                    Console.WriteLine("too many children, already checked in");
                    return Page();
                }
                 roomCheckIn2.Children[i].CheckedIn = true;

  
            }

            //*********************adults***********************//
            int numberOfAdultsAlreadyCheckedIn = 0;

            foreach (Adult adults in roomCheckIn2.Adults)
            {
                if (adults.CheckedIn == true)
                {
                    numberOfAdultsAlreadyCheckedIn++;
                }
            }

            for (int i = numberOfAdultsAlreadyCheckedIn; i <= Input.NrOfAdults; i++)
            {
                if (roomCheckIn2.Adults[i] == null)
                {
                    Console.WriteLine("too many adults, already checked in");
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

            [Required]
            [Display(Name = "Date")]
            public DateTime Date { get; set; }

        }
        
    }
}
