using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public partial class DepartmentModel : BaseModel
    {
        public DepartmentModel()
        {
            SubDepartments = new HashSet<DepartmentModel>();
        }

        public int? MainDepartmentId { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string DepartmentName { get; set; }

        [DisplayName("Logo")]
        public string DepartmentLogo { get; set; }

        public virtual DepartmentModel? MainDepartment { get; set; }
        public virtual ICollection<DepartmentModel> SubDepartments { get; set; }
    }
}
