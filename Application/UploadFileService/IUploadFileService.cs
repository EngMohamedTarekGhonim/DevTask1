using Core.Infrastracture.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UploadFileService
{
    public interface IUploadFileService
    {
        void UploadFile(DepartmentViewModel model, string webRootPath);

    }
}
