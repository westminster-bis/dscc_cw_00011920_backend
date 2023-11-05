using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal WorkingHours { get; set; }
    }
}
