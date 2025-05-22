using DesignPatternSampleCore.Models;
using System;

namespace DesignPatternSampleCore.Factories
{
    public abstract class EmployeeFactory
    {
        public abstract Employee CreateEmployee(string firstName, string lastName, string department);
    }
}
