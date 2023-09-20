using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VIPSeat : Seat
{
    // Property for the price multiplier for VIP seats
    public double PriceMultiplier { get; set; }

    // Constructor of the VIPSeat class
    public VIPSeat(int row, int number, bool isAvailable, double priceMultiplier)
        : base(row, number, isAvailable)
    {
        PriceMultiplier = priceMultiplier;
    }
}

