using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleAppDI
{
    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;
        private readonly IConfiguration _configuration;

        public MyClass(ILogger<MyClass> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void DoSometing()
        {
            var val = _configuration.GetValue<string>("myParam");
            _logger.LogInformation($"Called do something func with param {val}");
        }
    }
}
