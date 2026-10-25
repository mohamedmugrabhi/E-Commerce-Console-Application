namespace EcommerceApp
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product product { get; set; }

        public int OrderId { get; set; }

        public Order order { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, ProductId : {ProductId}, OrderId : {OrderId}, Quantity : {Quantity}";
        }
    }
}