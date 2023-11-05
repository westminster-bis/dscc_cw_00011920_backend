using Backend.DBcontext;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppointmentContext _context;

        public DoctorRepository(AppointmentContext context)
        {
            _context = context;
        }
        public void CreateDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            Save();
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            _context.Doctors.Remove(doctor);
            Save();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            
            return doctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;

            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private Doctor DoctorsExist(int id)
        {
            return _context.Doctors?.Where(e => e.Id == id).FirstOrDefault();
        }

    }
}
