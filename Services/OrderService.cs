using CampingApp.Data;
using CampingApp.Entities;
using CampingApp.Models;
using CampingApp.Services.Contract;
using Microsoft.EntityFrameworkCore;

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

				await UpdateSalesOrderReportsTable(orderId, order);
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
		private async Task UpdateSalesOrderReportsTable(int orderId, Order order)
		{
			try
			{
				List<SalesOrderReport> srItems = await (from oi in this.dbContext.OrderItems
														where oi.OrderId == orderId
														select new SalesOrderReport
														{
															OrderId = orderId,
															OrderDateTime = order.OrderDateTime,
															OrderPrice = order.Price,
															OrderQty = order.Qty,
															OrderItemId = oi.Id,
															OrderItemPrice = oi.Price,
															OrderItemQty = oi.Qty,
															EmployeeId = order.EmployeeId,
															EmployeeFirstName = dbContext.Employees.FirstOrDefault(e => e.Id == order.EmployeeId).FirstName,
															EmployeeLastName = dbContext.Employees.FirstOrDefault(e => e.Id == order.EmployeeId).LastName,
															ProductId = oi.ProductId,
															ProductName = dbContext.products.FirstOrDefault(p => p.Id == oi.ProductId).Name,
															ProductCategoryId = dbContext.products.FirstOrDefault(p => p.Id == oi.ProductId).CategoryId,
															ProductCategoryName = dbContext.ProductCategories.FirstOrDefault(c => c.Id == dbContext.products.FirstOrDefault(p => p.Id == oi.ProductId).CategoryId).Name,
															ClientId = order.ClientId,
															ClientFirstName = dbContext.Clients.FirstOrDefault(c => c.Id == order.ClientId).FirstName,
															ClientLastName = dbContext.Clients.FirstOrDefault(c => c.Id == order.ClientId).LastName,
															RetailOutletId = dbContext.Clients.FirstOrDefault(c => c.Id == order.ClientId).RetailOutletId,
															RetailOutletLocation = dbContext.RetailOutlets.FirstOrDefault(r => r.Id == dbContext.Clients.FirstOrDefault(c => c.Id == order.ClientId).RetailOutletId).Location
														}).ToListAsync();

				this.dbContext.AddRange(srItems);
				await this.dbContext.SaveChangesAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
