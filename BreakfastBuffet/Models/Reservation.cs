using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakfastBuffet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNr { get; set; } = 0;

        public List<Adult> Adults { get; set; } = null;

        public List<Child> Children { get; set; }

        //public DateTime Date { get; set; }

    }
}
