using System.Globalization;
public class Program
{
    static void Main()
    {
        DataService dataService = new DataService();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. View the list of movies");
            Console.WriteLine("2. View screenings for a movie");
            Console.WriteLine("3. Reserve a seat");
            Console.WriteLine("4. Exit the program");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    // View the list of movies
                    List<Movie> movies = dataService.GetMovies();
                    Console.WriteLine("List of movies:");
                    foreach (var movie in movies)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                    break;

                case "2":
                    Console.Clear();
                    // View screenings for a selected movie
                    Console.Write("Enter the movie title: ");
                    string movieTitle = Console.ReadLine();
                    Movie selectedMovie = dataService.GetMovies().Find(m => m.Title.Equals(movieTitle, StringComparison.OrdinalIgnoreCase));
                    if (selectedMovie != null)
                    {
                        List<Screening> screenings = dataService.GetScreenings().FindAll(s => s.Movie == selectedMovie);
                        Console.WriteLine($"Screenings for '{selectedMovie.Title}':");
                        foreach (var screening in screenings)
                        {
                            screening.DisplayAvailableSeats();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Movie with title '{movieTitle}' not found.");
                    }
                    break;

                case "3":
                    Console.Clear();
                    // Reserve a seat
                    Console.Write("Enter the movie title: ");
                    string filmTitle = Console.ReadLine();
                    Movie chosenMovie = dataService.GetMovies().Find(m => m.Title.Equals(filmTitle, StringComparison.OrdinalIgnoreCase));
                    if (chosenMovie != null)
                    {
                        DateTime currentDateTime = DateTime.Now;
                        Screening nearestScreening = dataService.GetScreenings()
                            .Where(s => s.Movie == chosenMovie && s.DateTime > currentDateTime)
                            .OrderBy(s => s.DateTime)
                            .FirstOrDefault();

                        if (nearestScreening != null)
                        {
                            Console.WriteLine($"The nearest screening for '{chosenMovie.Title}' is on {nearestScreening.DateTime}.");
                            Console.WriteLine("Available seats for this screening:");
                            nearestScreening.DisplayAvailableSeats();

                            Console.Write("Enter the row number: ");
                            if (int.TryParse(Console.ReadLine(), out int chosenRow))
                            {
                                Console.Write("Enter the seat number: ");
                                if (int.TryParse(Console.ReadLine(), out int chosenSeatNumber))
                                {
                                    Seat chosenSeat = nearestScreening.AvailableSeats.Find(seat => seat.Row == chosenRow && seat.Number == chosenSeatNumber);
                                    if (chosenSeat != null && chosenSeat.IsAvailable)
                                    {
                                        Console.Write("Enter your name: ");
                                        string customerName = Console.ReadLine();

                                        Reservation reservation = new Reservation(nearestScreening, chosenSeat, customerName);
                                        dataService.AddReservation(reservation);
                                        Console.WriteLine($"Seat reserved for {customerName}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Seat is not available or does not exist.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid seat number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid row number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No upcoming screenings found for '{chosenMovie.Title}'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Movie with title '{filmTitle}' not found.");
                    }
                    break;

                case "4":
                    Console.Clear();
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Unknown option. Please try again.");
                    break;
            }
        }
    }
}

