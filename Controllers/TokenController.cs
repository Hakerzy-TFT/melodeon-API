using System;
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
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IMongoCollectionDbContext _context;
        private IMongoCollection<Token> _dbCollection;
        //private IMongoCollection<TokenConfiguration> _tokenDbCollection;

        public TokenController(ILogger<TokenController> logger, IMongoCollectionDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Token>(typeof(Token).Name);
            _logger = logger;
            _logger.Log(LogLevel.Debug, "created TokenController");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Token>>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<Token>.Filter.Empty);
            return Ok(all.ToList());
        }

        [HttpPut]
        [Route("Create")]
        public async Task<ActionResult<Token>> Create(string request)
        {
            try
            {
                var req = JsonConvert.DeserializeObject<TokenDto>(request);
                var configCollection = await _dbCollection.FindAsync(Builders<Token>.Filter.Empty);
                var config = await CreateTokenConfig();
                Console.WriteLine("request:" + req.ToString());
                return Ok(";) -> " + request);
            }
            catch (Exception e)
            {
                return BadRequest("Couldn't process request: " + e);
            }
        }

        private async Task<Configuration> CreateTokenConfig()
        {
            var tokenDbCollection = _context.GetCollection<Configuration>(nameof(Configuration));
            var all = await tokenDbCollection.FindAsync(Builders<Configuration>.Filter.Empty);
            var val = all.ToList().ToArray();
            Console.WriteLine("All configs: " + val.ToArray()[0].lastLogin);
            // Console.WriteLine("Hello: " + maxIndex );

            return new Configuration();
        }
    }
}