using lazymode.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace lazymode
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private TaskManagerKiller taskManagerKiller;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await taskManagerKiller.ExecuteAsync();
                    await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogWarning($"Exception occured: {e.Message}");
                }
            }
        }
    }
}
