using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MelodeonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MelodeonApi.Controllers
{
    public class ServiceStatusController : ControllerBase
    {
        private readonly ILogger<ServiceStatusController> _logger;

        public ServiceStatusController(ILogger<ServiceStatusController> logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Debug, "created ServiceStatusLoggController");
        }

        public IEnumerable<ServiceStatus> Get()
        {
            _logger.Log(LogLevel.Debug, "activating ServiceStatusController");
            return Enumerable.Range(1, 1).Select(index => new ServiceStatus
                {
                    DebugMessage = "Service in debug mode",
                    ServiceStatusCode = 200
                })
                .ToArray();
        }
    }
}