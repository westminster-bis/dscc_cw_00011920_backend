using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    
    [Route("api/doctors")]
    [ApiController]
    public class DoctorContoller : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorContoller (IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        // GET: api/doctors
        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _doctorRepository.GetDoctors();
            return new OkObjectResult(doctors);
        }

        // GET api/<DoctorContoller>/5
        [HttpGet("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);
            return new OkObjectResult(doctor);
        }

        // POST api/<DoctorContoller>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doctor)
        {
            using (var scope = new TransactionScope())
            {
                _doctorRepository.CreateDoctor(doctor);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
            }

        }

        // PUT api/<DoctorContoller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Doctor doctor)
        {
            if (doctor != null)
            {
                using (var scope = new TransactionScope())
                {
                    _doctorRepository.UpdateDoctor(doctor);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<DoctorContoller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doctorRepository.DeleteDoctor(id);
            return new OkResult();
        }
    }
}
