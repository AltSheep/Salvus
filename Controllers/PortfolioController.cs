using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salvus.Data;
using Salvus.Dtos;
using Salvus.Models;
using System.Security.Claims;

namespace Salvus.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalvusRepo _repo;
        private readonly IMapper _mapper;

        public PortfolioController(ILogger<HomeController> logger, ISalvusRepo repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var assets = _repo.GetUserAssets(userId);

                return View(assets);
            }
            else
            {
                return Redirect("Identity/Account/Login");
            }
        }

        [HttpPost]
        public ActionResult<AssetDto> CreateAssetForUser(string coinSymbol)
        {
            if(!User.Identity.IsAuthenticated) { return NotFound(); }  

            var coin = _repo.GetAllCoins().SingleOrDefault(c => c.Symbol == coinSymbol);

            if(coin == null) { return NotFound(); }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newAsset = new Asset();
            newAsset.Ammount = 0;
            newAsset.Coin = coin;
            newAsset.CoinId = coin.Id;
            newAsset.User = _repo.GetUser(userId);
            newAsset.UserId = userId;

            _repo.AddAssetToUser(newAsset, userId);

            _repo.SaveChanges();

            return Ok(_mapper.Map<AssetDto>(newAsset));

            
        }
    }
}
