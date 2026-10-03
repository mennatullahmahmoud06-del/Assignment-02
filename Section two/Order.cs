namespace Assignment08_Section02
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Order {Id} :: Customer: {CustomerName} :: Price: {Price:C} :: Quantity: {Quantity}";
        }
    }
}