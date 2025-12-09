namespace DemoAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly StartDate {  get; set; }
        public decimal Salary { get; set; }
        public string Position {  get; set; }

    }
}
