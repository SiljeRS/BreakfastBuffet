using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Models;

namespace BreakfastBuffet.Pages
{
  public class RestaurantModel : PageModel
    {
        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();
        public void OnGet()
        {
            Input = new InputModel();
        }

        public IActionResult OnPost()
        {
            Reservation myReservation_ = new Reservation();

            myReservation_.RoomNr = Input.RoomNr;
            myReservation_.NrOfChildren = Input.NrOfChildren;
            myReservation_.NrOfAdults = Input.NrOfAdults;

            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage("Success");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Room number")]
            public int RoomNr { get; set; }

            [Required]
            [Display(Name = "Number of adults")]
            public int NrOfAdults { get; set; }

            [Required]
            [Display(Name = "Number of children")]
            public int NrOfChildren { get; set; }
        }
        
    }
}
