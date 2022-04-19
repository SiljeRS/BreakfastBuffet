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
        /*
        public IActionResult OnPost()
        {
            var breakfastDate _context.Reservation
        }
        */
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

