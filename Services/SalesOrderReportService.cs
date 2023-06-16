using CampingApp.Data;
using CampingApp.Entities;
using CampingApp.Extensions;
using CampingApp.Models.ReportModels;
using CampingApp.Services.Contract;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Grids;

namespace CampingApp.Services
{
    public class SalesOrderReportService : ISalesReportOrderService
    {
        private readonly CampingDbContext dbContext;
        private readonly AuthenticationStateProvider authenticationStateProvider;

		public SalesOrderReportService(CampingDbContext dbContext, AuthenticationStateProvider authenticationStateProvider)
        {
            this.dbContext = dbContext;
			this.authenticationStateProvider = authenticationStateProvider;
		}

        #region SR Sales Rep
        public async Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData()
        {
            try
            {
                var employee = await GetLoggedOnEmployee();

                var reportData = await (from s in dbContext.Sales
                                        where s.EmployeeId == employee.Id
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
                                            Price = Math.Round(GroupedData.Sum(o => o.OrderItemPrice), 2)
                                        }).ToListAsync();

                return reportData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GroupedFieldQtyModel>> GetQtyPerMonthData()
        {
            try
            {
                var employee = await GetLoggedOnEmployee();
                var reportData = await (from s in dbContext.Sales
                                        where s.EmployeeId == employee.Id
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
				var employee = await GetLoggedOnEmployee();

				var reportData = await (from s in dbContext.Sales
                                        where s.EmployeeId == employee.Id
                                        group s by s.ProductCategoryName into GroupedData
                                        orderby GroupedData.Key
                                        select new GroupedFieldQtyModel
                                        {
                                            GroupedFieldKey = GroupedData.Key,
                                            Qty = GroupedData.Sum(o => o.OrderItemQty)
                                        }).ToListAsync();

                return reportData;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region TL Team Leader
        public async Task<List<GroupedFieldPriceModel>> GetGrossSalesPerTeamMemberData()
        {
            try
            {
				var employee = await GetLoggedOnEmployee();

				List<int> teamMemberIds = await GetTeamMemberIds(employee.Id);

                var reportData = await (from s in dbContext.Sales
                                        where teamMemberIds.Contains(s.EmployeeId)
                                        group s by s.EmployeeFirstName into groupeData
                                        orderby groupeData.Key
                                        select new GroupedFieldPriceModel
                                        {
                                            GroupedFieldKey = groupeData.Key,
                                            Price = Math.Round(groupeData.Sum(o => o.OrderItemPrice), 2)
                                        }).ToListAsync();
                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<GroupedFieldQtyModel>> GetQtyPerTeamMemberData()
        {
            try
            {
				var employee = await GetLoggedOnEmployee();

				List<int> teamMemberIds = await GetTeamMemberIds(employee.Id);
                var reportData = await (from s in dbContext.Sales
                                        where teamMemberIds.Contains(s.EmployeeId)
                                        group s by s.EmployeeFirstName into groupeData
                                        orderby groupeData.Key
                                        select new GroupedFieldQtyModel
                                        {
                                            GroupedFieldKey = groupeData.Key,
                                            Qty = groupeData.Sum(o => o.OrderItemQty)
                                        }).ToListAsync();
                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<GroupedFieldQtyModel>> GetTeamQtyPerMonthData()
        {
            try
            {
				var employee = await GetLoggedOnEmployee();
				List<int> teamMemberIds = await GetTeamMemberIds(employee.Id);

                var reportData = await (from s in dbContext.Sales
                                        where teamMemberIds.Contains(s.EmployeeId)
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



        #endregion

        #region SM Sales Manager
        public async Task<List<LocationProductCategoryModel>> GetQtyLocationProductCatData()
        {
            try
            {

                var reportData = await (from s in dbContext.Sales
                                        group s by s.RetailOutletLocation into groupedData
                                        orderby groupedData.Key
                                        select new LocationProductCategoryModel
                                        {
                                            Location = groupedData.Key,
                                            MountainBikes = groupedData.Where(p => p.ProductCategoryId == 1).Sum(o => o.OrderItemQty),
                                            RoadBikes = groupedData.Where(p => p.ProductCategoryId == 2).Sum(o => o.OrderItemQty),
                                            Camping = groupedData.Where(p => p.ProductCategoryId == 3).Sum(o => o.OrderItemQty),
                                            Hiking = groupedData.Where(p => p.ProductCategoryId == 4).Sum(o => o.OrderItemQty),
                                            Boots = groupedData.Where(p => p.ProductCategoryId == 5).Sum(o => o.OrderItemQty)
                                        }).ToListAsync();

                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<GroupedFieldQtyModel>> GetQtyPerLocationData()
        {
            try
            {
                var reportData = (from s in dbContext.Sales
                                  group s by s.RetailOutletLocation into groupedData
                                  orderby groupedData.Key
                                  select new GroupedFieldQtyModel
                                  {
                                      GroupedFieldKey = groupedData.Key,
                                      Qty = groupedData.Sum(o => o.OrderItemQty)
                                  }).ToListAsync();
                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<MonthLocationModel>> GetQtyPerMonthLocationData()
        {
            try
            {
                var reportData = (from s in dbContext.Sales
                                  group s by s.OrderDateTime.Month into groupedData
                                  orderby groupedData.Key
                                  select new MonthLocationModel
                                  {
                                      Month = (
                                               groupedData.Key == 1 ? "Jan" :
                                               groupedData.Key == 2 ? "Feb" :
                                               groupedData.Key == 3 ? "Mar" :
                                               groupedData.Key == 4 ? "Apr" :
                                               groupedData.Key == 5 ? "May" :
                                               groupedData.Key == 6 ? "Jun" :
                                               groupedData.Key == 7 ? "Jul" :
                                               groupedData.Key == 8 ? "Aug" :
                                               groupedData.Key == 9 ? "Sep" :
                                               groupedData.Key == 10 ? "Oct" :
                                               groupedData.Key == 11 ? "Nov" :
                                               groupedData.Key == 12 ? "Dec" :
                                               ""
                                               ),
                                      TX = groupedData.Where(o => o.RetailOutletLocation == "TX").Sum(o => o.OrderItemQty),
                                      CA = groupedData.Where(o => o.RetailOutletLocation == "CA").Sum(o => o.OrderItemQty),
                                      NY = groupedData.Where(o => o.RetailOutletLocation == "NY").Sum(o => o.OrderItemQty),
                                      WA = groupedData.Where(o => o.RetailOutletLocation == "WA").Sum(o => o.OrderItemQty),
                                  }).ToListAsync();
                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private async Task<List<int>> GetTeamMemberIds(int teamLeadId)
        {
            List<int> teamMemberIds = await dbContext.Employees
                .Where(e => e.ReportToEmpId == teamLeadId)
                .Select(e => e.Id).ToListAsync();
            return teamMemberIds;
		}

		private async Task<Employee> GetLoggedOnEmployee()
		{
			var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
			var user = authState.User;

			return await user.GetEmployeeObject(dbContext);
		}
	}
}
