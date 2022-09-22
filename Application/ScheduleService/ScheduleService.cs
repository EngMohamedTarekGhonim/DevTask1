using Application.MailingService;
using AutoMapper;
using Core.Entities;
using Core.Infrastructure.Dtos;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ScheduleService
{
    public class ScheduleService :IScheduleService
    {
        private readonly IMailingService _mailingService;
        private readonly IMapper _mapper;

        public ScheduleService(IMailingService mailingService, IMapper mapper)
        {
            _mailingService = mailingService;
            _mapper = mapper;
        }

        public void Create_Schedule(ReminderModel reminderModel )
        {
            Console.WriteLine("Schedule created at : " + DateTime.Now.ToString() +"for time : "+ reminderModel.ReminderDate);
            // to call method now onlce
            //BackgroundJob.Enqueue(() => printlog("test message"));
            //
            BackgroundJob.Schedule(() => SendMessage(reminderModel), reminderModel.ReminderDate);
        }


        public void SendMessage(ReminderModel reminderModel)
        {
            Console.WriteLine("Email Send at time : " + DateTime.Now.ToString());

            MailRequestDto mailRequestDto = _mapper.Map<ReminderModel, MailRequestDto>(reminderModel);
            _mailingService.SendEmailAsync(mailRequestDto);
        }

        public void printlog(string body)
        {
            Console.WriteLine("printlog at time : " + DateTime.Now.ToString() + "with message : " + body);

        }

    }
}
