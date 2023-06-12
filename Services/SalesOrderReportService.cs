﻿using CampingApp.Data;
using CampingApp.Models.ReportModels;
using CampingApp.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace CampingApp.Services
{
	public class SalesOrderReportService : ISalesReportOrderService
	{
		private readonly CampingDbContext dbContext;

		public SalesOrderReportService(CampingDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData()
		{
			try
			{
				var reportData = await (from s in dbContext.Sales
										where s.EmployeeId == 9
										group s by s.OrderDateTime.Month into GroupedData
										orderby GroupedData.Key
										select new GroupedFieldPriceModel
										{
											GroupedFieldKey =
											(
												GroupedData.Key == 1 ? "Jan" :
												GroupedData.Key == 2 ? "Feb" :
												GroupedData.Key == 3 ? "Mar" :
												GroupedData.Key == 4 ? "Apr" :
												GroupedData.Key == 5 ? "May" :
												GroupedData.Key == 6 ? "Jun" :
												GroupedData.Key == 7 ? "Jul" :
												GroupedData.Key == 8 ? "Aug" :
												GroupedData.Key == 9 ? "Sep" :
												GroupedData.Key == 10 ? "Oct" :
												GroupedData.Key == 11 ? "Nov" :
												GroupedData.Key == 12 ? "Dec" :
												""
											),
											Price = Math.Round(GroupedData.Sum(o=>o.OrderItemPrice),2)
										}).ToListAsync();

				return reportData;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<List<GroupedFieldPriceModel>> GetGrossSalesPerTeamMemberData()
		{
			throw new NotImplementedException();
		}

		public async Task<List<GroupedFieldQtyModel>> GetQtyPerMonthData()
		{
			try
			{
				var reportData = await(from s in dbContext.Sales
									   where s.EmployeeId == 9
									   group s by s.OrderDateTime.Month into GroupedData
									   orderby GroupedData.Key
									   select new GroupedFieldQtyModel
									   {
										   GroupedFieldKey =
										   (
											   GroupedData.Key == 1 ? "Jan" :
											   GroupedData.Key == 2 ? "Feb" :
											   GroupedData.Key == 3 ? "Mar" :
											   GroupedData.Key == 4 ? "Apr" :
											   GroupedData.Key == 5 ? "May" :
											   GroupedData.Key == 6 ? "Jun" :
											   GroupedData.Key == 7 ? "Jul" :
											   GroupedData.Key == 8 ? "Aug" :
											   GroupedData.Key == 9 ? "Sep" :
											   GroupedData.Key == 10 ? "Oct" :
											   GroupedData.Key == 11 ? "Nov" :
											   GroupedData.Key == 12 ? "Dec" :
											   ""
										   ),
										   Qty = GroupedData.Sum(o => o.OrderItemQty)
									   }).ToListAsync();
				return reportData;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<GroupedFieldQtyModel>> GetQtyPerProductCategory()
		{

			try
			{
				var reportData = await (from s in dbContext.Sales
										group s by s.ProductCategoryName into GroupedData
										orderby GroupedData.Key
										select new GroupedFieldQtyModel
										{
											GroupedFieldKey=GroupedData.Key,
											Qty = GroupedData.Sum(o =>o.OrderItemQty)
										}).ToListAsync();

				return reportData;
			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}
