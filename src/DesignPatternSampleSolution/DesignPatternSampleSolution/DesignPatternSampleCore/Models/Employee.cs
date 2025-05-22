namespace DesignPatternSampleCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public System.DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} - {Department} (Hired: {HireDate.ToShortDateString()})";
        }
    }
}
