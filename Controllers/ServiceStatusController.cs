using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using MelodeonApi.Models;
using MelodeonApi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace MelodeonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceStatusController : ControllerBase
    {
        private readonly ILogger<ServiceStatusController> _logger;
        private readonly IMongoCollectionDbContext _context;
        private IMongoCollection<ServiceStatus> _dbCollection;

        public ServiceStatusController(ILogger<ServiceStatusController> logger, IMongoCollectionDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<ServiceStatus>(typeof(ServiceStatus).Name);
            _logger = logger;
            _logger.Log(LogLevel.Debug, "created ServiceStatus");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<ServiceStatus>>> Get()
        {
            _logger.Log(LogLevel.Debug, "running service status get request");
            var all = await _dbCollection.FindAsync(Builders<ServiceStatus>.Filter.Empty);
            return Ok(all.ToList().ToArray()[0]);
        }
    }
}