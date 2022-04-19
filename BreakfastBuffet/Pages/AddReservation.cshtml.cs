using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Data;
using BreakfastBuffet.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BreakfastBuffet.Pages
{
    public class AddReservationModel : PageModel
    {
        private readonly MyDbContext _context;
        public AddReservationModel(MyDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost()
        {
            Reservation reservation = new Reservation();

            for(int i = 0; i < Input.Adults; i++)
            {
                reservation.Adults.Add(new Adult());
            }

            for (int i = 0; i < Input.Children; i++)
            {
                reservation.Childen.Add(new Child());
            }

            reservation.Date = Input.Date;

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("Reception");
        }
        
        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        public class InputModel
        {
            //[Required]
            //public DateOnly Date { get; set; }
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

