using System;

namespace Assignment08_Section02
{
    public static class OrderActions
    {
        // Part 4: at least three actions, as Action<Order> lambdas.
        public static readonly Action<Order> PrintOrderInfo = order =>
            Console.WriteLine($"[Print] {order}");

        public static readonly Action<Order> SendConfirmation = order =>
            Console.WriteLine($"[Confirmation] Dear {order.CustomerName}, your order {order.Id} has been confirmed.");

        public static readonly Action<Order> WriteAudit = order =>
            Console.WriteLine($"[Audit] Order {order.Id} processed at {DateTime.Now:T}.");
    }
}
