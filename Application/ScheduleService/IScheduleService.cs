using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ScheduleService
{
    public interface IScheduleService
    {
        void Create_Schedule(ReminderModel reminderModel);
        
    }
}
