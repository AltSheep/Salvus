using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Salvus.Data;

namespace Salvus.Controllers.Api
{
    [Route("api/salvus")]
    [ApiController]
    public class SalvusApiController : ControllerBase
    {
        private readonly ISalvusRepo _repo;
        private readonly IMapper _mapper;

        public SalvusApiController(ISalvusRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<String>> GetCoinSymbolList()
        {
            List<String> coinSymbols = new List<String>();

            var coins = _repo.GetAllCoins();
            foreach (var coin in coins)
            {
                coinSymbols.Add(coin.Id);
            }
            
            return Ok(coinSymbols);
        }
    }
}