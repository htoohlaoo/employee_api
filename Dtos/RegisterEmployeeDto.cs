using DemoAPI.Enum;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace DemoAPI.Dtos
{
    public record RegisterEmployeeDto
    {
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

/*
{
    "name": "Alice Smith",
  "email": "alice.smith@example.com",
  "dateOfBirth": "1992-08-15",
  "startDate": "2025-01-01",
  "salary": 500000,
  "position": "Developer"
}
*/