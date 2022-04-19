using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BreakfastBuffet.Data;

namespace BreakfastBuffet.Pages
{
    public class ReceptionModel : PageModel
    {
        private readonly MyDbContext _context;
        public ReceptionModel(MyDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        public class InputModel
        {
            /*[Required]
            public string Name { get; set; }*/
        }
    }
}
