namespace DemoAPI.Dtos
{
    public record UpdateDepartmentDto
    {
        public string Name { get; set; }               // Department name
        public string Description { get; set; }        // Department description
        public Guid? HeadId { get; set; }              // Optional Head (Employee) Id
    }
}
