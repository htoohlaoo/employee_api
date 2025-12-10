namespace DemoAPI.Dtos
{
    public class GetDepartmentDto
    {
        public Guid Id { get; set; }               // Department Id
        public string Name { get; set; }           // Department Name
        public string Description { get; set; }    // Department Description
        public Guid? HeadId { get; set; }
    }
}
