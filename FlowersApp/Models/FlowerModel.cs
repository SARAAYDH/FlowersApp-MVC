using System.ComponentModel.DataAnnotations;

namespace FlowersApp.Models
{
    public class FlowerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Display(Name= "Availability")]
        public string Status { get; set; } = string.Empty;
        [Display(Name = "Number of Available Flowers")]
        public int StockQuantity { get; set; }
        public string Picture { get; set; } = string.Empty;
        public decimal Price { get; set;}
       
    }
}
