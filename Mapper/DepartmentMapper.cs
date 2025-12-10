using DemoAPI.Dtos;
using DemoAPI.Models;

namespace DemoAPI.Mapper
{
    public static class DepartmentMapper
    {
        public static GetDepartmentDto ToResponse(this Department department)
        {
            if (department == null) return null;

            return new GetDepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                HeadId = department.HeadId
            };
        }

        public static void UpdateFromDto(this Department department, UpdateDepartmentDto dto)
        {
            if (dto == null) return;

            department.Name = dto.Name;
            department.Description = dto.Description;
            department.HeadId = dto.HeadId;
        }

    }
}
