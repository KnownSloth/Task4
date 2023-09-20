using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DataService
{
    private List<Movie> movies = new List<Movie>();
    private List<Screening> screenings = new List<Screening>();
    private List<Reservation> reservations = new List<Reservation>();

    public DataService()
    {
        Movie movie1 = new Movie("X-Men", 105, 12, 13.40);
        Movie movie2 = new Movie("Smile", 115, 18, 15.50);
        AddMovie(movie1);
        AddMovie(movie2);

        // Create seats for the first screening with VIP seats in the last row
        List<Seat> seats1 = new List<Seat>();
        for (int row = 1; row <= 3; row++)
        {
            for (int number = 1; number <= 3; number++)
            {
                if (row == 3) // Check if it's the last row for VIP seats
                {
                    seats1.Add(new VIPSeat(row, number, true, 1.5));
                }
                else
                {
                    seats1.Add(new Seat(row, number, true));
                }
            }
        }

        // Create seats for the second screening with all regular seats
        List<Seat> seats2 = new List<Seat>();
        for (int row = 1; row <= 3; row++)
        {
            for (int number = 1; number <= 3; number++)
            {
                seats2.Add(new Seat(row, number, true));
            }
        }

        Screening screening1 = new Screening(movie1, DateTime.Now.AddHours(1), seats1, 1.0);
        Screening screening2 = new Screening(movie2, DateTime.Now.AddHours(2), seats2, 1.0);

        AddScreening(screening1);
        AddScreening(screening2);
    }

    // Method to add a movie to the list of movies
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
    }

    // Method to add a screening to the list of screenings
    public void AddScreening(Screening screening)
    {
        screenings.Add(screening);
    }

    // Method to add a reservation to the list of reservations
    public void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    // Method to get the list of movies
    public List<Movie> GetMovies()
    {
        return movies;
    }

    // Method to get the list of screenings
    public List<Screening> GetScreenings()
    {
        return screenings;
    }

    // Method to get the list of reservations
    public List<Reservation> GetReservations()
    {
        return reservations;
    }
}
