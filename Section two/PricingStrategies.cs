using System;

namespace Assignment08_Section02
{
    public static class PricingStrategies
    {
        // Part 1: two methods matching the PriceCalculator delegate signature.
        public static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }

        public static decimal CalculateTotalWithDiscount(Order order)
        {
            const decimal flatDiscount = 10m;
            return (order.Price * order.Quantity) - flatDiscount;
        }

        // Bonus Challenge: a dictionary mapping strategy names to
        // Func<Order, decimal> implementations.
        private static readonly System.Collections.Generic.Dictionary<string, Func<Order, decimal>> _strategies =
            new System.Collections.Generic.Dictionary<string, Func<Order, decimal>>
            {
                ["Normal"] = order => order.Price * order.Quantity,
                ["Discount10"] = order => (order.Price * order.Quantity) * 0.90m,
                ["Discount20"] = order => (order.Price * order.Quantity) * 0.80m,
                ["VIP"] = order => (order.Price * order.Quantity) * 0.50m
            };

        public static Func<Order, decimal> GetStrategy(string name)
        {
            return _strategies[name];
        }
    }
}
