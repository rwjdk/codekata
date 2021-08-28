using System.ComponentModel.DataAnnotations;

namespace WebApplicationOData.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
    }
}