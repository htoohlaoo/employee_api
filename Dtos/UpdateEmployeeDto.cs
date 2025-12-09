using DemoAPI.Enum;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoAPI.Dtos
{
    public class UpdateEmployeeDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        [Range(300000, 30000000, ErrorMessage = "Salary must be at least 300000.")]
        public decimal Salary { get; set; }
        [Required]

        [JsonConverter(typeof(StringEnumConverter))]
        public Positions Position { get; set; }
    }
}
