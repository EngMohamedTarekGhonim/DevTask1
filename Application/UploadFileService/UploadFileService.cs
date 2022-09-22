using Core.Infrastracture.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UploadFileService
{
    public class UploadFileService : IUploadFileService
    {

        public void UploadFile(DepartmentViewModel model , string webRootPath)
        {
            string uploadsFolder = Path.Combine(webRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.DepartmentLogoFormFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.DepartmentLogoFormFile.CopyTo(fileStream);
                model.DepartmentLogo = uniqueFileName;
            }
        }

    }
}
