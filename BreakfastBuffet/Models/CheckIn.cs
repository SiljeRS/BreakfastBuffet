﻿namespace BreakfastBuffet.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public List<Reservation> Reservations{ get; set; }
    }
}
