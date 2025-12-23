namespace Furni.App.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; } //product-1.png
        public string ImageUrl { get; set; }//https://localhost:7275/assets/images/product-1.png
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
