using PaparaFirstWeek.Model;
using System.Collections.Generic;

namespace PaparaFirstWeek.Data
{
    public class EmployeeData
    {
        public List<Employee> GetAllEmployee()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Department = "HR",
                    Age = 24,
                    City = "New York",
                    Gender = "Male"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Elif",
                    Department = "IT",
                    Age = 23,
                    City = "Istanbul",
                    Gender = "FeMale"
                },
                 new Employee
                {
                    Id = 3,
                    Name = "Tuğba",
                    Department = "Mobil Software",
                    Age = 20,
                    City = "Istanbul",
                    Gender = "FeMale"
                },
                  new Employee
                {
                    Id = 4,
                    Name = "Samet Kayıkcı",
                    Department = "Ios Software",
                    Age = 20,
                    City = "Istanbul",
                    Gender = "Male"
                }
            };
        }
    }

}
