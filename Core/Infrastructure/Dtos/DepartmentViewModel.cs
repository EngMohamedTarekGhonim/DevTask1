using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Infrastracture.Dtos
{
    public class DepartmentViewModel
    {
        public int? MainDepartmentId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string DepartmentName { get; set; }

        [DisplayName("Logo Image")]
        [Required(ErrorMessage = "Please choose Logo image")]
        public IFormFile DepartmentLogoFormFile { get; set; }

        public string? DepartmentLogo { get; set; }


    }
}
