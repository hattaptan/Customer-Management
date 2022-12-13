using CustomerManagement.Configurations.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Configurations.Manager
{
    public class DomainManager : IDomainService
    {
        private readonly IConfiguration _configuration;

        public DomainManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         public string Address()
        {
            var host = _configuration.GetSection("Host").Value;
            return host;
        }
    }
}
