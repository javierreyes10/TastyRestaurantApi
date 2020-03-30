using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TastyRestaurant.Api.Services
{
    public class CloudMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public CloudMailService(IConfiguration configuration)//access to appsettings.json
        {
            _configuration = configuration;
        }
        public void Send(string subject, string message)
        {
            Trace.WriteLine($"Mail from {_configuration["mailSettings:mailFromAddress"]} to {_configuration["mailSettings:mailToAddress"]}, with Cloud Mail Service");
            Trace.WriteLine($"Subject: {subject}");
            Trace.WriteLine($"Message: {message}");
        }
    }
}
