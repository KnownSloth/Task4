using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Movie
{
    // Property for the movie title
    public string Title { get; set; }

    // Property for the movie duration in minutes
    public int Duration { get; set; }

    // Property for the age rating
    public int AgeRating { get; set; }

    // Property for the ticket price
    public double TicketPrice { get; set; }

    // Constructor of the class to initialize a Movie object
    public Movie(string title, int duration, int ageRating, double ticketPrice)
    {
        Title = title;
        Duration = duration;
        AgeRating = ageRating;
        TicketPrice = ticketPrice; // Initialize TicketPrice
    }

    // Override the ToString() method for convenient display of movie information
    public override string ToString()
    {
        return $"Title: {Title}, Duration: {Duration} min, Age Rating: {AgeRating}+, Ticket Price: ${TicketPrice}";
    }
}

