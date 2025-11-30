using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_10.State;
using lab_10.Strategy;

namespace lab_10.Shared.Models
{
    public partial class Order
    {
        public IOrderState State { get; set; } = new CreatedState();

        public IPricingStrategy PricingStrategy { get; set; }

        public double DistanceKm { get; set; }

        public void NextState()
        {
            State.Next(this);
        }

        public void PrevState()
        {
            State.Prev(this);
        }

        public void PrintState()
        {
            State.PrintStatus();
        }

        public void ApplyPricing()
        {
            if (PricingStrategy == null)
            {
                Console.WriteLine("⚠ Не вибрано тариф!");
                return;
            }

            Price = PricingStrategy.CalculatePrice(DistanceKm);
            Console.WriteLine($"💰 Нова ціна: {Price} грн");
        }
    }
}
