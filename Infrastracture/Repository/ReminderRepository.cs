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
    public class ReminderRepository : BaseRepository<Core.Entities.ReminderModel>, IReminderRepository
    {
        public ReminderRepository(AppDataContext context) : base(context)
        {

        }

        public IEnumerable<SelectListItem> ReminderForDropdown()
        {
            return All().ToList().Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });
        }

    }

}
