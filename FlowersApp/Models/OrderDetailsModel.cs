namespace FlowersApp.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public OrderModel Order {  get; set; }
        public FlowerModel Flower { get; set; }

    }
}