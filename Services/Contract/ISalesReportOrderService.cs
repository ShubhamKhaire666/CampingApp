using CampingApp.Models.ReportModels;

namespace CampingApp.Services.Contract
{
	public interface ISalesReportOrderService
	{
		Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData();
	}
}
