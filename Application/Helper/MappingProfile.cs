using AutoMapper;
using Core.Entities;
using Core.Infrastracture.Dtos;
using Core.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastracture.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DepartmentModel, DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentModel, DepartmentDetailsDto>().ReverseMap();
            CreateMap<ReminderModel, MailRequestDto>()
                .ForMember(c => c.ToEmail, o => o.MapFrom(m => m.Email))
                .ForMember(c => c.Body, o => o.MapFrom(m => m.Body))
                .ForMember(c => c.Subject, o => o.MapFrom(m => m.Title))
                .ReverseMap();

        }
    }
}
