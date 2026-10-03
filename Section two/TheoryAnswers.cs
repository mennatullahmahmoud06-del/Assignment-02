// Section 02 - Theory Questions

// Q1. Difference between PriceCalculator and Func<Order, decimal>?
// They have the IDENTICAL signature (Order in, decimal out) and are
// functionally interchangeable - a method or lambda matching one also
// matches the other. The difference is purely about DECLARATION and
// NAMING: PriceCalculator is a custom delegate TYPE we declared ourselves,
// giving the concept a domain-specific name ("this delegates to a price
// calculation"). Func<Order, decimal> is the built-in generic delegate -
// no declaration needed, but it carries no domain meaning in its name; you
// have to read the generic parameters to know what it represents.

// Q2. Difference between Action<Order> and Func<Order, decimal>?
// Action<Order> represents a method that takes an Order and returns
// NOTHING (void) - it performs a side effect (printing, logging, sending
// a notification). Func<Order, decimal> represents a method that takes an
// Order and RETURNS a decimal value - it computes and hands back a result.
// In short: Action = "do something", Func = "calculate and return something".

// Q3. Why does Predicate<T> return bool? What problem is it designed for?
// Predicate<T> is specifically designed to represent a TEST or CONDITION
// applied to a value of type T - answering a yes/no question about that
// value (e.g. "is this order valid?", "does this item match?"). Returning
// bool is exactly what a yes/no test needs. It's commonly used for
// filtering, searching, and validation scenarios (e.g. List<T>.Find,
// List<T>.FindAll both accept a Predicate<T>) where the caller needs to
// supply a custom "does this qualify?" rule.

// Q4. Difference between a delegate and an event?
// A delegate is a TYPE - essentially a type-safe function pointer that can
// be assigned, reassigned, passed around, and invoked freely by anyone who
// holds a reference to it. An event is a special wrapper AROUND a delegate
// field that restricts what external code can do with it: outside the
// declaring class, code can only SUBSCRIBE (+=) or UNSUBSCRIBE (-=) - it
// cannot invoke the event directly or overwrite the whole subscriber list
// with "=". The declaring class is the only one allowed to raise (invoke) it.

// Q5. Why can't external code normally invoke an event declared in another class?
// Because the "event" keyword hides the underlying delegate's public
// Invoke() ability from outside the declaring class - the compiler only
// exposes += and -= to external code. This enforces a one-directional
// relationship: only the class that owns the event decides WHEN the event
// fires (encapsulation), while any number of outside listeners can react
// to it without being able to trigger it themselves or interfere with
// other subscribers.

// Q6. What happens when multiple handlers subscribe to the same event?
// The event becomes a MULTICAST delegate - internally, all subscribed
// methods are chained together in an invocation list. When the event is
// raised (Invoke() / ?.Invoke()), every subscribed handler in that list
// runs, one after another, in the order they were subscribed. This is
// demonstrated in Program.cs where handler1, handler2, and handler3 all
// execute from a single ProcessOrder(order) call.

// Q7. orderService.OrderProcessed += HandleOrderProcessed;
// - OrderProcessed: the event field declared inside OrderService
//   (an Action<Order> under the hood) - the "notification point" that
//   other code can react to.
// - +=: the SUBSCRIBE operator for multicast delegates/events - it adds
//   HandleOrderProcessed to the event's internal invocation list WITHOUT
//   removing any handler that was already subscribed.
// - HandleOrderProcessed: a method (or lambda) matching the event's
//   delegate signature (Action<Order> -> takes an Order, returns void)
//   that will now be called every time OrderProcessed is raised.
// Put together: "whenever orderService's OrderProcessed event fires, also
// call HandleOrderProcessed, in addition to any handlers already subscribed."

// Q8 (Challenge). Difference between Action<Order> and event Action<Order>?
// A plain public field of type Action<Order> is just a delegate variable -
// ANY external code can not only subscribe/unsubscribe to it, but also
// INVOKE it directly, or even overwrite the entire list with a single "="
// assignment (accidentally wiping out every other subscriber). Declaring
// it as "event Action<Order>" restricts external code to ONLY += and -=,
// preventing outside code from invoking the notification itself or
// clobbering other subscribers' handlers. We use "event" specifically to
// protect the integrity of the notification mechanism: only OrderService
// should decide when "OrderProcessed" actually happens, while any number
// of independent listeners can safely react to it without stepping on
// each other or being able to trigger false notifications.
