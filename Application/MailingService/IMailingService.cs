using Core.Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MailingService
{
    public interface IMailingService
    {
        Task SendEmailAsync(MailRequestDto mailRequestDto);
    }
}