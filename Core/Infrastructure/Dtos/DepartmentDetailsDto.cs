using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastracture.Dtos
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLogo { get; set; }
        public virtual IEnumerable<DepartmentModel>? MainDepartments { get; set; }
        public virtual IEnumerable<DepartmentModel>? SubDepartments { get; set; }

    }
}
