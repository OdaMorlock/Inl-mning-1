using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Temperature
{
    public class Worker : BackgroundService 
    {
        private readonly ILogger<Worker> _logger;

        
        




        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
           
            _logger.LogInformation("The service has been started.");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            
            _logger.LogInformation("The service has been stopped.");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                int temperature;
                Random random = new Random();
                temperature = random.Next(1, 1000);

                 

                try
                {
                    if (temperature <= 750)
                        _logger.LogInformation($"The Temperature is within normal peramatures {temperature}C");
                    else
                        _logger.LogInformation($"The Temeprature is too high {temperature}C");
                }
                catch (Exception)
                {

                    
                }

                await Task.Delay(60*1000, stoppingToken);
            }
        }
    }
}
