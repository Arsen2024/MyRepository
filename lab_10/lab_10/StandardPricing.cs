using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.Strategy
{
    public class StandardPricing : IPricingStrategy
    {
        public double CalculatePrice(double distance)
        {
            return distance * 10;
        }
    }
}
