using CampingApp.Models.ReportModels;

namespace CampingApp.Services.Contract
{
	public interface ISalesReportOrderService
	{
		//SR
		Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData();
		Task<List<GroupedFieldQtyModel>> GetQtyPerProductCategory();
		Task<List<GroupedFieldQtyModel>> GetQtyPerMonthData();

		//TL
		Task<List<GroupedFieldPriceModel>> GetGrossSalesPerTeamMemberData();
		Task<List<GroupedFieldQtyModel>> GetQtyPerTeamMemberData();
		Task<List<GroupedFieldQtyModel>> GetTeamQtyPerMonthData();

        //SM
        Task<List<LocationProductCategoryModel>> GetQtyLocationProductCatData();
        Task<List<GroupedFieldQtyModel>> GetQtyPerLocationData();
        Task<List<MonthLocationModel>> GetQtyPerMonthLocationData();


    }
}
