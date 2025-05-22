using DesignPatternSampleCore.Factories;
using DesignPatternSampleCore.Models;
using System;
namespace DesignPatternSampleSolution.DesignPatternSampleCore.Factories
{
    public class RegularEmployeeFactory : EmployeeFactory
    {
        public override Employee CreateEmployee(string firstName, string lastName, string department)
        {
            // ここで RegularEmployee を生成するなど。
            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Department = department,
                HireDate = DateTime.Now
            };
        }
    }
}
