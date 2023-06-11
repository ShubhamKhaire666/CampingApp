using CampingApp.Data;
using CampingApp.Entities;
using CampingApp.Models;
using CampingApp.Services.Contract;

namespace CampingApp.Services
{
	public class OrderService : IOrderService
	{
		private readonly CampingDbContext dbContext;

		public OrderService(CampingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task CreateOrder(OrderModel orderModel)
		{
			try
			{
				Order order = new Order
				{
					OrderDateTime = DateTime.Now,
					ClientId = orderModel.ClientID,
					EmployeeId = 9,
					Price = orderModel.OrderItems.Sum(o=>o.Price),
					Qty = orderModel.OrderItems.Sum(o=>o.Qty)
				};

				var addedOrder = await dbContext.Orders.AddAsync(order);
				await dbContext.SaveChangesAsync();
				int orderId = addedOrder.Entity.Id;

				var orderItemsToAdd = ReturnOrderItemsWithOrderId(orderId, orderModel.OrderItems);

				dbContext.AddRange(orderItemsToAdd);

				await dbContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private List<OrderItem> ReturnOrderItemsWithOrderId(int orderId, List<OrderItem> orderItems)
		{
			return (from oi in orderItems
				   select new OrderItem
				   {
					   OrderId = orderId,
					   Price = oi.Price,
					   Qty = oi.Qty,
					   ProductId = oi.ProductId,
				   }).ToList();
		}
	}
}
