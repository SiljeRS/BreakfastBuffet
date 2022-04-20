using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BreakfastBuffet.Data;
using BreakfastBuffet.Models;
using System.ComponentModel.DataAnnotations;

namespace BreakfastBuffet.Pages
{
    public class BreakfastOverviewModel : PageModel
    {
        private readonly MyDbContext _context;
        public BreakfastOverviewModel(MyDbContext context)
        {
            _context = context;
        }

        public List<Reservation> CheckInOverviewList { get; set; }

        public void OnGet()
        {
            CheckInOverviewList = _context.CheckInOverview
                .Where(x => x.Date.Day == DateTime.Now.Day)
                .Select(x => x.reservationsCheckedIn)
                .FirstOrDefault();
            //if(CheckInOverview == null)
        }
    }
}
