using Core.Entities;
using Core.Interface;
using Core.Interface.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepartmentService
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public IEnumerable<ReminderModel> GetAll()
        {
            return _reminderRepository.All();
        }

        public ReminderModel ReminderDetails(int id)
        {
            return _reminderRepository.Find(id);
        }
        public void AddReminder(ReminderModel reminder)
        {
            reminder.CreatedDate = DateTime.Now;
            _reminderRepository.Insert(reminder);
        }

       
    }
}
