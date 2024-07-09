using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
    // TODO: review BFS/DFS

    /*
    
A turn-based strategy game has a grid with water and land. The grid contains a true value where it's
water and false where it's land.

The player controls a boat unit with a particular movement pattern. It can only move to fixed destinations
from its current position as shown in the image below:

Right: 2 spaces
Up: 1 space
Left: 1 space
Down: 1 space
    
The boat can only move in a direct path through water to the possible destinations, so a destination will
become unreachable if there is land in the way.

Implement the CanTravelTo function, that checks whether a destination is reachable by the boat. It
should return true for destinations that are reachable according to the pattern above, and false for
unreachable or out of bounds destinations which are outside the grid.

    */
    internal static class BoatMovements
    {
        public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
        {
            throw new NotImplementedException("Waiting to be implemented");
        }

        public static void Main_BoatMovements()
        {
            bool[,] gameMatrix =
            {
            {false, true,  true,  false, false, false},
            {true,  true,  true,  false, false, false},
            {true,  true,  true,  true,  true,  true},
            {false, true,  true,  false, true,  true},
            {false, true,  true,  true,  false, true},
            {false, false, false, false, false, false},
        };

            Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
            Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
            Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
        }
    }
}
