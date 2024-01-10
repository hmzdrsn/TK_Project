using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendMail(Mail mail);
        Task WriteQueue(Mail mail);
        Task ReceiveQueueAndSendMail();
    }
}
