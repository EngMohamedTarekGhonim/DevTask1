using Core.Interface.BaseRepository;
using Core.Entities;
using Infrastracture.AppDbContext;
using Infrastracture.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infrastracture.Repository
{
    public class DepartmentRepository : BaseRepository<Core.Entities.DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(AppDataContext context) : base(context)
        {

        }

        public IEnumerable<SelectListItem> DepartmentForDropdown()
        {
            return All().ToList().Select(x => new SelectListItem()
            {
                Text = x.DepartmentName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<DepartmentModel> SubDepartments(int MainDepartmentId)
        {
            return All().Where(x => x.MainDepartmentId == MainDepartmentId).ToList();
        }

        public IEnumerable<DepartmentModel> FindAllParents( DepartmentModel child)
        {
            var parent = All().FirstOrDefault(x => x.Id == child.MainDepartmentId);

            if (parent == null)
                return Enumerable.Empty<DepartmentModel>();

            return new[] { parent }.Concat(FindAllParents(parent));
        }


    }

}
