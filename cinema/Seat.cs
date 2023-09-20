using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Seat
{
    // Property for the row of the seat
    public int Row { get; set; }

    // Property for the seat number
    public int Number { get; set; }

    // Property indicating whether the seat is available
    public bool IsAvailable { get; set; }

    // Constructor of the class to initialize a Seat object
    public Seat(int row, int number, bool isAvailable)
    {
        Row = row;
        Number = number;
        IsAvailable = isAvailable;
    }

    internal double CalculatePrice(double priceMultiplier)
    {
        throw new NotImplementedException();
    }
}
