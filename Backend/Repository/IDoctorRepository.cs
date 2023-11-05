using Backend.Model;

namespace Backend.Repository
{
    public interface IDoctorRepository
    {
        void CreateDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int doctorId);
        Doctor GetDoctorById(int doctorId);
        IEnumerable<Doctor> GetDoctors();
    }
}
