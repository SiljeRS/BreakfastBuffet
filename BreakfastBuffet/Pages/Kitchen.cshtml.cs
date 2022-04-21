
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

        public KitchenModel(MyDbContext context, IHubContext<KitchenHub, IKitchen> kitchenHubContext)
        {
            _context = context;
            _kitchenHubContext = kitchenHubContext;
        }

        public async Task OnPost()
        {
            var myBreakfast = await GetBreakfast(Input.Date);

            if (myBreakfast != null)
            {
                _expectedAmountOfAdults = myBreakfast.NAdults;
                _expectedAmountOfChildren = myBreakfast.NChildren;

                _expectedAmountOfPeople = _expectedAmountOfAdults + _expectedAmountOfChildren;
            }
            else
            {
                ModelState.AddModelError("Input.Date", "There are no expected guests on the chosen date");
            }

            var myCheckInOverview = await GetCheckinOverview(Input.Date);
            if (myCheckInOverview != null)
            {
                foreach (Reservation reservation in myCheckInOverview.reservationsCheckedIn)
                {
                    _amountOfAdultsCheckedIn += reservation.NrAdults;
                    _amountOfChildrenCheckedIn += reservation.NrChildren;
                }
            }
            else
            {
                ModelState.AddModelError("Input.Date", "There are no checked-in guests on the chosen date");
            }

        }
        
        public async Task OnGet()
        {
            var myBreakfast = await GetBreakfast(Input.Date);
            if(myBreakfast != null )
            {
                _expectedAmountOfAdults = myBreakfast.NAdults;
                _expectedAmountOfChildren = myBreakfast.NChildren;

                _expectedAmountOfPeople = _expectedAmountOfAdults + _expectedAmountOfChildren;
            }
            else
            {
                ModelState.AddModelError("Input.Date", "There are no expected guests on the chosen date");
            }

            var myCheckInOverview = await GetCheckinOverview(DateTime.Now);
            if(myCheckInOverview != null)
            {
                foreach (Reservation reservation in myCheckInOverview.reservationsCheckedIn)
                {
                    _amountOfAdultsCheckedIn += reservation.NrAdults;
                    _amountOfChildrenCheckedIn += reservation.NrChildren;
                }
            }
            else
            {
                ModelState.AddModelError("Input.Date", "There are no checked-in guests on the chosen date");
            }
            
        }
        
        private async Task<Breakfast?> GetBreakfast(DateTime date)
        {
            return await _context.Breakfast
                .Where(p => p.Date.Day == date.Day)
                .FirstOrDefaultAsync();
        }

        private async Task<CheckInOverview?> GetCheckinOverview(DateTime date)
        {
            return await _context.CheckInOverview
                .Where(p => p.Date.Day == date.Day)
                .Include(x => x.reservationsCheckedIn)
                .FirstOrDefaultAsync();
        }

        
        [BindProperty]
        public InputModel? Input { get; set; } = new InputModel();
        
        public class InputModel
        {
            [Required]
            public DateTime Date { get; set; } = DateTime.Now;

   
        }
        
        
    }
}