using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Entities
{
    public partial class ReminderModel : BaseModel
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
       
        [DisplayName("Reminder Date")]
        public DateTime ReminderDate { get; set; }
        public int state { get; set; }
    }
}
