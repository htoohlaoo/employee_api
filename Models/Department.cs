namespace DemoAPI.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Guid? HeadId { get; set; }
        public Employee? Head { get; set; }
    }
}
