using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Core.Interface.BaseRepository
{
   public interface IReminderRepository : IRepository<Entities.ReminderModel>
    {
        IEnumerable<SelectListItem> ReminderForDropdown();

    }

}
