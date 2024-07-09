using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
/*
     
A gaming company is working on a platformer game. 
    
They need a method that will compute the character's final speed, given a map and a starting speed.

The terrain on which the game character moves forward is made from various pieces of land
placed together. 
    
Implement the method CalculateFinalSpeed which takes the initial speed of the
character, and an array of degrees of inclination that represent the uneven terrain.

The speed of the character will increase or decrease proportionally to the incline of the land, as
shown in the image below:

Start: 0 degrees, 60 km/h
Phase 1: 30 degrees, 30 km/h
Phase 2: 0 degrees, 30 km/h
Phase 3: -45 degrees, 75 km/h
Phase 4: 0 degrees, 75 km/h

The magnitude of the angle of inclination will always be < 90 degrees. The speed change occurs only
once for each piece of land. The method should immediately return O as the final speed if an
incline reduces the speed to O or below O, which makes the character lose 1 life.

For example, the below code:

Console.WriteLine(CalculateFinalSpeed(60, new int[] (0, 30, 0, -45, 0}));

should print: 75

*/

    public static class GamePlatform
    {
        public static double CalculateFinalSpeed(double initialSpeed, int[] inclinations)
        {
            var output = initialSpeed;

            foreach (var incline in inclinations)
            {
                if (incline > 0)
                {
                    output -= incline;
                }
                else
                {
                    output += Math.Abs(incline);
                }      

                if (output <= 0) return 0;
            }

            return output;
        }

        public static void Main_GamePlatform()
        {
            Console.WriteLine(CalculateFinalSpeed(60, new int[] { 0, 30, 0, -45, 0 }));
        }
    }
}
