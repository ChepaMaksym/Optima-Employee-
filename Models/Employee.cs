
namespace Optima_Employee_
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public decimal Salary { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public Employee()
        {
                
        }
        public Employee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Address = employee.Address;
            DateOfBirth = employee.DateOfBirth;
            Phone = employee.Phone;
            Position = employee.Position;
            Status = employee.Status;
            Salary = employee.Salary;
            HiringDate = employee.HiringDate;
            DismissalDate = employee.DismissalDate;
        }
    }
}
