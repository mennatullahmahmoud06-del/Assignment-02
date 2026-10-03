using System;

namespace Assignment08_Section02
{
    public static class OrderValidationRules
    {
        // Part 3: at least three validation rules, as Predicate<Order> lambdas.
        public static readonly Predicate<Order> HasPositiveQuantity = order => order.Quantity > 0;
        public static readonly Predicate<Order> HasPositivePrice = order => order.Price > 0;
        public static readonly Predicate<Order> HasCustomerName = order => !string.IsNullOrWhiteSpace(order.CustomerName);
    }
}
