using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DBcontext
{
    public class AppointmentContext : DbContext
    {
        // Constructors DO NOT FORGET That Product Context class extends DB Context
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }
    }
}
