using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ReadAppSettings.json
{
    public class OtherClass
    {
        private readonly IConfigurationRoot _config;

        public OtherClass(IConfigurationRoot config)
        {
            _config = config;
        }

        public void Run()
        {
            Console.WriteLine(_config.GetSection("DbConnectionConfig").GetSection("ServerName").Value);
            Console.WriteLine(_config.GetSection("DbConnectionConfig").GetSection("DatabaseName").Value);
            Console.WriteLine(_config.GetSection("DbConnectionConfig").GetSection("UserName").Value);
            Console.WriteLine(_config.GetSection("DbConnectionConfig").GetSection("Password").Value);

            Console.WriteLine(_config.GetConnectionString("DataConnection"));

            Console.WriteLine(_config.GetValue<string>("DbConnectionConfig:ServerName"));

            var contactEmails = _config.GetSection("ContactEmails").Get<List<string>>();
            foreach (var email in contactEmails) Console.WriteLine(email);
        }
    }
}