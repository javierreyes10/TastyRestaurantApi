using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TastyRestaurant.Api.Services
{
    public class LocalMailService : IMailService
    {
        private readonly IConfiguration _configuration;
         
        public LocalMailService(IConfiguration configuration)//access to appsettings.json
        {
            _configuration = configuration;
        }

        public void Send(string subject, string message)
        {
            Trace.WriteLine($"Mail from {_configuration["mailSettings:mailFromAddress"]} to {_configuration["mailSettings:mailToAddress"]}, with local service");
            Trace.WriteLine($"Subject: {subject}");
            Trace.WriteLine($"Message: {message}");
        }
    }
}
