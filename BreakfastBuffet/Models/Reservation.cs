using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakfastBuffet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNr { get; set; } = 0;

         public int NrAdults { get; set; }

         public int NrChildren { get; set; }

        //public DateOnly Date { get; set; }
        public DateTime Date { get; set; }

    }
}
