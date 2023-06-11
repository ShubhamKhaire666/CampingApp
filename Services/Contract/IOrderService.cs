using CampingApp.Models;

namespace CampingApp.Services.Contract
{
	public interface IOrderService
	{
		Task CreateOrder(OrderModel order);
	}
}
