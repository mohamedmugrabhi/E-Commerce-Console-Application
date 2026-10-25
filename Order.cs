namespace EcommerceApp
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public Customer customer { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Total : {TotalAmount}, Date : {Date}, CustomerId : {CustomerId}";
        }
    }
}