using System.ComponentModel.DataAnnotations;

namespace HRMS.API.Dtos
{
    public class DepartmentResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}