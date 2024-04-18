
namespace Optima_Employee_.Data
{
    public class DataSeed
    {
        public List<Employee> GenerateTestData()
        {
            List<Employee> testData = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                Employee person = new Employee
                {
                    Id = i,
                    Name = $"Employee {i}",
                    Address = $"Address {i}",
                    DateOfBirth = new DateTime(1990 + i, i+1, i+1),
                    Phone = $"+380-68-111-111{i}",
                    Position = $"Position {i}",
                    Status = $"Status {i}",
                    Salary = 100000 + i * 100,
                    HiringDate = new DateTime(2017, i + 1, i + 1),
                };
                if (i % 2 == 0)
                    person.DismissalDate = DateTime.Now.AddDays(i);
                testData.Add(person);
            }

            return testData;
        }
    }
}
