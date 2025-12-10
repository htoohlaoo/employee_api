using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Dtos
{
    public record CreateDepartmentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // Optional: Assign department head during creation
        public Guid? HeadId { get; set; }
    }
}
