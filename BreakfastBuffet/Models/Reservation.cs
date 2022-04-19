using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakfastBuffet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNr { get; set; } = 0;

        public List<Adult> Adults { get; set; } = null;

        public List<Children> Children { get; set; } = null;

        //[Column(TypeName="Date")]
        public DateTime Date { get; set; }

    }
}
