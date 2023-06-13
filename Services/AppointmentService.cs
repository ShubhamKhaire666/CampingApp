using CampingApp.Data;
using CampingApp.Entities;
using CampingApp.Extensions;
using CampingApp.Models;
using CampingApp.Services.Contract;

namespace CampingApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly CampingDbContext dbContext;

        public AppointmentService(CampingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                Appointment appointment = appointmentModel.Convert();
                await dbContext.AddAsync(appointment);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAppointment(int Id)
        {
            try
            {
                Appointment? appointment = await dbContext.Appointments.FindAsync(Id);

                if (appointment != null)
                {

                    dbContext.Appointments.Remove(appointment);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AppointmentModel>> GetAppointments()
        {
            try
            {
                return await dbContext.Appointments.Where(e=>e.EmployeeId == 9).Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                Appointment? appointment = await dbContext.Appointments.FindAsync(appointmentModel.Id);

                if (appointment != null)
                {
                    appointment.Description = appointmentModel.Description;
                    appointment.Location = appointmentModel.Location;
                    appointment.IsAllDay = appointmentModel.IsAllDay;
                    appointment.RecurrenceRule = appointmentModel.RecurrenceRule;
                    appointment.RecurrenceId = appointmentModel.RecurrenceId;
                    appointment.RecurrenceException = appointmentModel.RecurrenceException;
                    appointment.StartTime = appointmentModel.StartTime;
                    appointment.EndTime = appointmentModel.EndTime;
                    appointment.Subject = appointmentModel.Subject;

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
