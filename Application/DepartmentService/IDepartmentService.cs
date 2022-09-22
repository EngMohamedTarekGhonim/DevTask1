using Core.Entities;
using Core.Infrastracture.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Core.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAll();
        IEnumerable<DepartmentModel> GetMainDepartments(DepartmentModel ChildDep);
        IEnumerable<DepartmentModel> GetSubDepartments(int MainDepartmentId);
        DepartmentDetailsDto GetDepartmentDetails(int DepartmentId);
        DepartmentModel DepartmentInfo(int id);
        void AddDepartment(DepartmentViewModel departmentViewModel);
        IEnumerable<SelectListItem> DepartmentForDropdown();





    }
}
