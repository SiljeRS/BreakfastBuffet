
using BreakfastBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using BreakfastBuffet.Hubs;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BreakfastBuffet.Models;

namespace BreakfastBuffet.Pages
{
    public class KitchenModel : PageModel
    {
        private readonly IHubContext<KitchenHub, IKitchen> _kitchenHubContext;
        private readonly MyDbContext _context;

        public int _expectedAmountOfAdults;
        public int _expectedAmountOfChildren;
        public int _expectedAmountOfPeople;

        public int _amountOfAdultsCheckedIn;
        public int _amountOfChildrenCheckedIn;


        public KitchenModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> _kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = _kitchenHubContext;
        }

        public void OnGet()
        {
            //Expected
            var myBreakfast = _context.Breakfast.Where(p => p.Date.Day == DateTime.Now.Day).FirstOrDefault();
            _expectedAmountOfAdults = myBreakfast.NAdults;
            _expectedAmountOfChildren = myBreakfast.NChildren;

            _expectedAmountOfPeople = _expectedAmountOfAdults + _expectedAmountOfChildren;

            //Checked In 
            var myCheckInOverview = _context.CheckInOverview.Where(p => p.Date.Day == DateTime.Now.Day).Include(x => x.reservationsCheckedIn).FirstOrDefault();
            
            foreach (Reservation reservation in myCheckInOverview.reservationsCheckedIn)
            {
                _amountOfAdultsCheckedIn += reservation.NrAdults;
                _amountOfChildrenCheckedIn += reservation.NrChildren;
            }


        }

        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required]
            public DateTime Date { get; set; }

            
        }
        */
    }
}