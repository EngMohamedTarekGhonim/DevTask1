using Application.UploadFileService;
using AutoMapper;
using Core.Entities;
using Core.Infrastracture.Dtos;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _DepartmentService;
        private readonly IUploadFileService _uploadFileService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;



        public DepartmentController(IDepartmentService DepartmentService,IUploadFileService uploadFileService, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _DepartmentService = DepartmentService;
            _uploadFileService = uploadFileService;
            _webHostEnvironment = hostEnvironment;
            _mapper = mapper;
        }



        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(_DepartmentService.GetAll());
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            ViewBag.MainDepartmentId = _DepartmentService.DepartmentForDropdown();
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]  /*security in post request*/
        public ActionResult Create(DepartmentViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DepartmentViewModel departmentViewModelAfterUploading = UploadedFile(model);
                    _DepartmentService.AddDepartment(departmentViewModelAfterUploading);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_DepartmentService.GetDepartmentDetails(id));
        }


        private DepartmentViewModel UploadedFile(DepartmentViewModel model)
        {

            if (model.DepartmentLogoFormFile != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                _uploadFileService.UploadFile(model, webRootPath);
            }
            return model;
        }

    }
}
