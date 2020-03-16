using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TastyRestaurant.Api.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@company.com";
        private string _mailFrom = "noreply@company.com";

        public void Send(string subject, string message)
        {
            Trace.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with Cloud Mail Service");
            Trace.WriteLine($"Subject: {subject}");
            Trace.WriteLine($"Message: {message}");
        }
    }
}
