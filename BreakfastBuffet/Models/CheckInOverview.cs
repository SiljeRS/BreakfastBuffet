namespace BreakfastBuffet.Models
{
    public class CheckInOverview
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Reservation> reservationsCheckedIn { get; set; }
    }
}
