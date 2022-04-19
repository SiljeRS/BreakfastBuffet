﻿
namespace BreakfastBuffet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNr { get; set; } = 0;

        public List<Adult> Adults { get; set; }

        public List<Child> Children { get; set; }

        public DateOnly Date { get; set; }

    }
}
