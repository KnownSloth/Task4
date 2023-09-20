using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Reservation
{
    // Property for the screening that the reservation is made for
    public Screening Screening { get; set; }

    // Property for the reserved seat
    public Seat Seat { get; set; }

    // Property for the customer's name who made the reservation
    public string CustomerName { get; set; }

    // Constructor of the class to initialize a Reservation object
    public Reservation(Screening screening, Seat seat, string customerName)
    {
        Screening = screening;
        Seat = seat;
        CustomerName = customerName;

        // Set the IsAvailable status of the seat to false upon reservation
        seat.IsAvailable = false;
    }
}
