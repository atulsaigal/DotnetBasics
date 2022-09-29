namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public long Salary { get; set; }

        public DateTime DateOfBrth { get; set; }

        public string Department { get; set; }




    }
}
