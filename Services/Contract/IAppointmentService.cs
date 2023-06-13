using CampingApp.Models;

namespace CampingApp.Services.Contract
{
    public interface IAppointmentService
    {
        Task<List<AppointmentModel>> GetAppointments();

        Task AddAppointment(AppointmentModel appointment);
        Task UpdateAppointment(AppointmentModel appointment);
        Task DeleteAppointment(int Id);
    }
}
