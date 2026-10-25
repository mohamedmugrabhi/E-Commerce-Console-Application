namespace EcommerceApp
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category category { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Name : {Name}, Price : {Price}, CategoryId : {CategoryId}";
        }
    }
}