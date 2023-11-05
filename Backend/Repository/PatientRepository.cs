using Backend.DBcontext;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Numerics;

namespace Backend.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentContext _context;

        public PatientRepository(AppointmentContext context)
        {
            _context = context;
        }
        public void DeletePatientRecord(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            _context.Patients.Remove(patient);
            Save();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.Join(_context.Doctors, 
                patient => patient.AssignedDoctorId, 
                doctor => doctor.Id, (patient, doctor) => new Patient 
                { PatientIllness = patient.PatientIllness, 
                    FullName = patient.FullName, 
                    Id = patient.Id, 
                    AssignedDoctorId = doctor.Id,
                    Age = patient.Age,
                    AssignedDoctor = doctor
                });
        }

        public Doctor GetPatientAssignedDoctor(int patientId)
        {
            var patient = GetPatientById(patientId);

           
            var doctor = _context.Doctors.Find(patient.AssignedDoctorId);

            return doctor;
            
        }

        public Patient GetPatientById(int Id)
        {
            var patient = _context.Patients.Join(_context.Doctors,
                patient => patient.AssignedDoctorId,
                doctor => doctor.Id, (patient, doctor) => new Patient
                {
                    PatientIllness = patient.PatientIllness,
                    FullName = patient.FullName,
                    Id = patient.Id,
                    AssignedDoctorId = doctor.Id,
                    Age = patient.Age,
                    AssignedDoctor = doctor
                }).ToList<Patient>().Find(patient => patient.Id.Equals(Id));

            return patient;
        }

        public void RegisterPatient(Patient patient)
        {
            _context.Add(patient);
            Save();
        }

        public void UpdatePatientInfo(Patient patient)
        {
            _context.Entry(patient).State =
             Microsoft.EntityFrameworkCore.EntityState.Modified;
            
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
