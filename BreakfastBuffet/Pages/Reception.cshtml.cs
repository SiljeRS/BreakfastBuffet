using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BreakfastBuffet.Data;
using BreakfastBuffet.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace BreakfastBuffet.Pages
{
    //[Authorize(Policy = "ReceptionOnly")]
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
   
    }
}
