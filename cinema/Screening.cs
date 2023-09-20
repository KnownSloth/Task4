using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Screening
{
    // Property for the movie being shown at the screening
    public Movie Movie { get; set; }

    // Property for the date and time of the screening
    public DateTime DateTime { get; set; }

    // Property for the list of available seats
    public List<Seat> AvailableSeats { get; private set; }

    // Property for the price multiplier
    public double PriceMultiplier { get; set; } // Added PriceMultiplier property

    // Constructor of the class to initialize a Screening object
    public Screening(Movie movie, DateTime dateTime, List<Seat> totalSeats, double priceMultiplier = 1.0)
    {
        Movie = movie;
        DateTime = dateTime;
        AvailableSeats = totalSeats;
        PriceMultiplier = priceMultiplier; // Initialize PriceMultiplier
    }

    // Method to display available seats for reservation with price info
    public void DisplayAvailableSeats()
    {
        // Iterate through the list of seats and display only the available ones
        foreach (var seat in AvailableSeats)
        {
            if (seat.IsAvailable)
            {
                double ticketPrice = Movie.TicketPrice;

                // Check if the seat is VIP and apply the PriceMultiplier if it is
                if (seat is VIPSeat)
                {
                    VIPSeat vipSeat = (VIPSeat)seat;
                    ticketPrice *= vipSeat.PriceMultiplier;
                }

                // Use Math.Round to round the ticketPrice to two decimal places
                ticketPrice = Math.Round(ticketPrice, 2);

                if (seat is VIPSeat)
                {
                    Console.WriteLine($"VIP Seat - Row {seat.Row}, Number {seat.Number}, Price: ${ticketPrice:F2}");
                }
                else
                {
                    Console.WriteLine($"Regular Seat - Row {seat.Row}, Number {seat.Number}, Price: ${ticketPrice:F2}");
                }
            }
        }

        // If all seats are occupied, display the appropriate message
        if (AvailableSeats.TrueForAll(seat => !seat.IsAvailable))
        {
            Console.WriteLine("All seats are occupied.");
        }
    }
}
