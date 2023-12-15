using System.Collections;

namespace FlowersApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId {  get; set; }

        public ICollection<OrderDetailsModel> OrderDetails {  get; set; }

    }
}
