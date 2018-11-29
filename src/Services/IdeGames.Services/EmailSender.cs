using System;
using System.Threading.Tasks;
using IdeGames.Services.Contracts;

namespace IdeGames.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}