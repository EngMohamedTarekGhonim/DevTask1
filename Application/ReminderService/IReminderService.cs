using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IReminderService
    {
        IEnumerable<ReminderModel> GetAll();
        ReminderModel ReminderDetails(int id);
        void AddReminder(ReminderModel reminder);



    }
}
