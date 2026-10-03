using System;

namespace Assignment08_Section02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            Order order = new Order
            {
                Id = 1,
                CustomerName = "Mona Adel",
                Price = 100m,
                Quantity = 3
            };

            #region Part 1 - User-defined delegate (PriceCalculator)

            decimal total1 = orderService.CalculateOrderPrice(order, PricingStrategies.CalculateTotal);
            Console.WriteLine("CalculateTotal: " + total1);

            decimal total2 = orderService.CalculateOrderPrice(order, PricingStrategies.CalculateTotalWithDiscount);
            Console.WriteLine("CalculateTotalWithDiscount: " + total2);

            #endregion

            #region Part 2 - Func<Order, decimal>

            Func<Order, decimal> plainCalc = (x) => x.Price * x.Quantity;
            Func<Order, decimal> discountCalc = (x) => (x.Price * x.Quantity) * 0.9m;

            Console.WriteLine("Func plain: " + orderService.CalculateOrderPriceFunc(order, plainCalc));
            Console.WriteLine("Func discount: " + orderService.CalculateOrderPriceFunc(order, discountCalc));

            // Q: What problem does Func<> solve compared with a custom delegate?
            // Func<Order, decimal> is a BUILT-IN generic delegate type that
            // already matches "takes an Order, returns a decimal", so we
            // don't need to declare our own "PriceCalculator" delegate type
            // at all. It saves a type declaration, works immediately with
            // any matching lambda/method, and is instantly recognizable to
            // any C# developer without needing to look up what
            // "PriceCalculator" means. The trade-off is that a custom
            // delegate (like PriceCalculator) gives the parameter a
            // MEANINGFUL NAME in the method signature, which can make the
            // code's intent clearer at the call site - Func<> is generic
            // and anonymous by comparison.

            #endregion

            #region Part 3 - Predicate<Order>

            bool validQuantity = orderService.ValidateOrder(order, OrderValidationRules.HasPositiveQuantity);
            bool validPrice = orderService.ValidateOrder(order, OrderValidationRules.HasPositivePrice);
            bool validName = orderService.ValidateOrder(order, OrderValidationRules.HasCustomerName);

            Console.WriteLine($"Valid quantity: {validQuantity}, Valid price: {validPrice}, Valid name: {validName}");

            // Q: Why is Predicate<Order> more expressive than Func<Order, bool>
            // here, even though both represent the same signature?
            // Functionally they ARE interchangeable (Predicate<T> is really
            // just Func<T, bool> under a different name) - but Predicate<T>
            // communicates INTENT: its name literally says "this is a yes/no
            // TEST or CONDITION applied to a value," which matches exactly
            // what validation rules are. Func<T, bool> is generic and could
            // represent any boolean-returning computation, not necessarily a
            // validation check. Using Predicate<Order> for validation rules
            // makes the code more self-documenting at the call site.

            #endregion

            #region Part 4 - Action<Order>

            orderService.ProcessOrder(order, OrderActions.PrintOrderInfo);
            orderService.ProcessOrder(order, OrderActions.SendConfirmation);
            orderService.ProcessOrder(order, OrderActions.WriteAudit);

            #endregion

            #region Part 5 & 6 - Events, multicast, subscribe/unsubscribe

            Action<Order> handler1 = o => Console.WriteLine($"[Handler1] Order {o.Id} - printing message.");
            Action<Order> handler2 = o => Console.WriteLine($"[Handler2] Order {o.Id} - sending notification.");
            Action<Order> handler3 = o => Console.WriteLine($"[Handler3] Order {o.Id} - writing audit log.");

            orderService.OrderProcessed += handler1;
            orderService.OrderProcessed += handler2;
            orderService.OrderProcessed += handler3;

            Console.WriteLine("-- Processing with all 3 handlers subscribed --");
            orderService.ProcessOrder(order); 

            orderService.OrderProcessed -= handler1;

            Console.WriteLine("-- Processing after unsubscribing Handler1 --");
            orderService.ProcessOrder(order);

            #endregion

            #region Bonus Challenge - runtime-selectable pricing strategies

            Order vipOrder = new Order { Id = 2, CustomerName = "Omar Tarek", Price = 200m, Quantity = 2 };

            Func<Order, decimal> normalPricing = PricingStrategies.GetStrategy("Normal");
            Func<Order, decimal> vipPricing = PricingStrategies.GetStrategy("VIP");

            Console.WriteLine("Normal pricing: " + orderService.CalculateOrderPriceFunc(vipOrder, normalPricing));
            Console.WriteLine("VIP pricing: " + orderService.CalculateOrderPriceFunc(vipOrder, vipPricing));

            #endregion
        }
    }
}