using AutoMapper;
using Core.Entities;
using Core.Infrastracture.Dtos;
using Core.Interface;
using Core.Interface.BaseRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;


        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;

        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            return _departmentRepository.All();
        }
        public DepartmentModel DepartmentInfo(int id)
        {
            return _departmentRepository.Find(id);
        }
        public void AddDepartment(DepartmentViewModel departmentViewModel)
        {
            DepartmentModel newDepartment = _mapper.Map<DepartmentViewModel, DepartmentModel>(departmentViewModel);
            _departmentRepository.Insert(newDepartment);
        }

        public IEnumerable<DepartmentModel> GetMainDepartments(DepartmentModel ChildDep)
        {
           return  _departmentRepository.FindAllParents(ChildDep);
        }
      
        public IEnumerable<DepartmentModel> GetSubDepartments(int MainDepartmentId)
        {
            return _departmentRepository.SubDepartments(MainDepartmentId);
        }
       
        public DepartmentDetailsDto GetDepartmentDetails(int DepartmentId)
        {
            DepartmentModel selectedDepartment = _departmentRepository.Find(DepartmentId);
            DepartmentDetailsDto selectedDepartmentDetails = _mapper.Map<DepartmentModel, DepartmentDetailsDto>(selectedDepartment);
            selectedDepartmentDetails.MainDepartments = GetMainDepartments(selectedDepartment);
            selectedDepartmentDetails.SubDepartments = GetSubDepartments(DepartmentId);
            return selectedDepartmentDetails;
        }

        public IEnumerable<SelectListItem> DepartmentForDropdown()
        {
            return _departmentRepository.All().ToList().Select(x => new SelectListItem()
            {
                Text = x.DepartmentName,
                Value = x.Id.ToString()
            });
        }

    }
}
