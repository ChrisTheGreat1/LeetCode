using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
    /*

    A megastore offers three types of discounts, which are represented as DiscountType enum.

    Implement the GetDiscountedPrice method which should take the total weight of the shopping
    cart, the total price, and the discount type. 
    
    It should return the final discounted price based on the
    discount schemes as shown in the promotional video below:

    Standard discount: weight = any, discount = 6%

    Seasonal discount: weight = any, discount = 12%

    Weight discount: weight <= 10, discount = 6%
    Weight discount: weight > 10, discount = 18%


    For example:

    Console.WriteLine(GetDiscountedPrice(12, 100, DiscountType.Weight));
        
    Should print: 82.0

    */
    internal static class MegaStore
    {
        public enum DiscountType
        {
            Standard,
            Seasonal,
            Weight
        }

        public static double GetDiscountedPrice(double cartWeight,
                                                double totalPrice,
                                                DiscountType discountType)
        {
            // Standard discount: weight = any, discount = 6%
            if (discountType == DiscountType.Standard)
            {
                return totalPrice * (1 - 0.06);
            }

            // Seasonal discount: weight = any, discount = 12%
            else if (discountType == DiscountType.Seasonal)
            {
                return totalPrice * (1 - 0.12);
            }

            // Weight discount: weight <= 10, discount = 6%
            // Weight discount: weight > 10, discount = 18 %
            else if (discountType == DiscountType.Weight)
            {
                if (cartWeight <= 10)
                {
                    return totalPrice * (1 - 0.06);
                }
                else
                {
                    return totalPrice * (1 - 0.18);
                }
            }

            else return 0;
        }

        public static void Main_MegaStore()
        {
            Console.WriteLine(GetDiscountedPrice(12, 100, DiscountType.Weight));
        }
    }
}
