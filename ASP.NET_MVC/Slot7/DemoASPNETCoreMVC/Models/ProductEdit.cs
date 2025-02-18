namespace DemoASPNETCoreMVC.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }
    }
}
