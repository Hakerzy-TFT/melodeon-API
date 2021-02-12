using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> Create(string request)
        {
            var req = JsonConvert.DeserializeObject<TokenDto>(request);
            Console.WriteLine("request:" + req.ToString());
            return Ok(";) -> " + request);
        }
    }
}