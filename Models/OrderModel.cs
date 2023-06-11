using CampingApp.Entities;

namespace CampingApp.Models
{
	public class OrderModel
	{
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal Price { get; set; }

        public int Qty { get; set; }
        public int EmployeeId { get; set; }
        public int ClientID { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
