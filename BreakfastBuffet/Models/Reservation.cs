
namespace BreakfastBuffet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNr { get; set; } = 0;

        public int NrOfAdults { get; set; } = 0;

        public int NrOfChildren { get; set; } = 0;

    }
}
