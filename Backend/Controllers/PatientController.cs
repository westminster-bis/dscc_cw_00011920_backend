using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        // GET: api/patient/list
        [HttpGet]
        public IActionResult Get()
        {
            var patients = _patientRepository.GetPatients();

            return new OkObjectResult(patients);
        }

        // GET api/patient/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patient = _patientRepository.GetPatientById(id);
            return new OkObjectResult(patient);
        }

        // POST api/patient/register
        [HttpPost]
        public IActionResult Post([FromBody] Patient patient)
        {
            using (var scope = new TransactionScope())
            {
                _patientRepository.RegisterPatient(patient);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
            }
        }

        // PUT api/patient/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Patient patient)
        {
            _patientRepository.UpdatePatientInfo(patient);
            return new OkResult();
        }

        // DELETE api/patient/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _patientRepository.DeletePatientRecord(id);
            return new OkResult();
        }
    }
}
