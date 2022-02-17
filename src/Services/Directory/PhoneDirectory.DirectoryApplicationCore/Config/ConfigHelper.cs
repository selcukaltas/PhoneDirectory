using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Config
{
    public class ConfigHelper
    {
        private readonly IConfiguration _configuration;
        public ConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string RabbitMqCon => _configuration["RabbitMq"] ?? "";

    }
}
