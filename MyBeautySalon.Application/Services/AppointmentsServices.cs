using Microsoft.EntityFrameworkCore;
using MyBeautySalon.Domain;
using MyBeautySalon.Models;
using MyBeautySalon.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeautySalon.Application.Services
{
    public class AppointmentsServices
    {
        private readonly DataContext _context;
        public AppointmentsServices(DataContext context)
        {
            _context = context; 
        }
        public async Task<List<AppointmentModel>> GetAll() { 
            var appointmentsDb = await _context.Appointments.ToListAsync();
            var appointments = new List<AppointmentModel>();
            foreach (var appointmentsDb in appointmentsDb)
            {
                appointments.Add(new AppointmentModel()
                {
                    Id = appointmentsDb.Id,
                    Date = appointmentsDb.Date,
                    CustomerName = appointmentsDb.CustomerName
                });

                return appointments;

            }
   
        
        }
        public async Task<AppointmentModel> Get(int Id)
        {
            var appointmentsDb = await _context.Appointments.FindAsync(Id);
            var appointment = new AppointmentModel
            {
                Id = appointmentsDb.Id,
                Date = appointmentsDb.Date,
                CustomerName = appointmentsDb.CustomerName
            };
            return appointment;

        }
        public bool Create(AppointmentModel appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
               
            }
            return false;

        }
        public bool Modified(AppointmentModel appointment)
        {
            try
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;

        }
        public bool Remove(AppointmentModel appointment)
        {
            try
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;

        }
    }
}
