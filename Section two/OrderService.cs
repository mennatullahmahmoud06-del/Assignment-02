using System;

namespace Assignment08_Section02
{
    public class OrderService
    {
        // Part 5: event other parts of the application subscribe to.
        public event Action<Order>? OrderProcessed;

        // Part 1: uses the user-defined delegate to calculate price.
        public decimal CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            return calculator(order);
        }

        // Part 2: same operation, but accepting the built-in Func<> instead
        // of the user-defined PriceCalculator delegate. 
        public decimal CalculateOrderPriceFunc(Order order, Func<Order, decimal> calculator)
        {
            return calculator(order);
        }

        // Part 3: validates an order against any supplied rule.
        public bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }

        // Part 4: executes the supplied behavior after "processing" the order.
        public void ProcessOrder(Order order, Action<Order> action)
        {
            action(order);
        }

        // Part 5: processes the order and raises the OrderProcessed event so
        // every subscriber gets notified, regardless of how many there are.
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing order {order.Id}...");
            OrderProcessed?.Invoke(order);
        }
    }
}