using Backend.Model;

namespace Backend.Repository
{
    public interface IPatientRepository
    {
        void RegisterPatient(Patient patient);
        void UpdatePatientInfo(Patient patient);
        void DeletePatientRecord(int patientId);
        Patient GetPatientById(int Id);
        Doctor GetPatientAssignedDoctor(int doctorId);
        IEnumerable<Patient>GetPatients();
    }
}
