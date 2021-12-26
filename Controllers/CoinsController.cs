using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;

using Salvus.Dtos;
using Salvus.Data;

namespace Salvus.Controllers
{
    [Route("api/coins")]
    [ApiController]
    public class CoinsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalvusRepo _repo;
        private readonly IMapper _mapper;

        public CoinsController(ILogger<HomeController> logger, ISalvusRepo repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CoinDto>> GetCoins()
        {
            var coins = _repo.GetAllCoins();

            return Ok(_mapper.Map<IEnumerable<CoinDto>>(coins));
        }
    }
}