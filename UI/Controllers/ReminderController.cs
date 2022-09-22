using Application.ScheduleService;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ReminderController : Controller
    {

        private readonly IReminderService _reminderService;
        private readonly IScheduleService _scheduleService;

        public ReminderController( IReminderService reminderService , IScheduleService scheduleService)
        {
            _reminderService = reminderService;
            _scheduleService = scheduleService;
        }



        // GET: ReminderController
        public ActionResult Index()
        {
            return View(_reminderService.GetAll());
        }

        // GET: ReminderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReminderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]  /*security in post request*/
        public ActionResult Create(ReminderModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reminderService.AddReminder(obj);
                    _scheduleService.Create_Schedule(obj);
                    return RedirectToAction(nameof(Index)); /*return to index view*/
                }
                return View(obj);
            }
            catch
            {
                return View();
            }
        }

    }
}
