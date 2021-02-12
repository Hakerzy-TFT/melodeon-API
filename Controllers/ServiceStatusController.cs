using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelodeonApi.Models;
using MelodeonApi.Models.Dtos;
using MelodeonApi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MelodeonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceStatusController : ControllerBase
    {
        private readonly ILogger<ServiceStatusController> _logger;
        private readonly IMongoCollectionDbContext _context;
        private readonly IMongoCollection<ServiceStatus> _dbCollection;

        public ServiceStatusController(ILogger<ServiceStatusController> logger, IMongoCollectionDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<ServiceStatus>(nameof(ServiceStatus));
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

        [HttpPost]
        [Route("Set")]
        public async Task<ActionResult<ServiceStatus>> Set(string inputJson)
        {
            _logger.Log(LogLevel.Debug, "running service status SetStatus request");
            try
            {
                var dto = JsonConvert.DeserializeObject<ServiceStatusDto>(inputJson);
                Console.WriteLine("API: " + dto.Api);

                var all = await _dbCollection.FindAsync(Builders<ServiceStatus>.Filter.Empty);
                var targetId = all.ToList().ToArray()[0]._id;

                var filter = Builders<ServiceStatus>
                    .Filter.Eq(e => e._id, targetId);

                string targetJson = JsonConvert.SerializeObject(dto);
                await _dbCollection.FindOneAndUpdateAsync(filter, targetJson);

                return Ok(targetJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in SetServiceStatus: " + e);
                _logger.Log(LogLevel.Debug, "Exception in SetServiceStatus: " + e);
                return BadRequest("Exception in SetServiceStatus");
            }
        }
    }
}