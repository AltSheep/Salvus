using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salvus.Data;
using Salvus.Dtos;
using Salvus.Models;

namespace Salvus.Controllers.Api
{
    
    [ApiController]
    public class PortfolioApiController : ControllerBase
    {
        private readonly ISalvusRepo _repo;
        private readonly IMapper _mapper;

        public PortfolioApiController(ISalvusRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<IEnumerable<AssetDto>> GetUsersPortfolio(string userId)
        {
            var assets = _repo.GetUserAssets(userId);

            if (assets.Count() <= 0) { return NotFound(); }

            foreach (var asset in assets)
            {
                
               Console.WriteLine(asset.Coin.Name);
            }

            return Ok(_mapper.Map<IEnumerable<AssetDto>>(assets));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<IEnumerable<AssetDto>> AddAssetToUser(CoinDto newCoin)
        {
            Console.WriteLine("ADDING NEW ASSET: " + newCoin.Id);

            if(!User.Identity.IsAuthenticated) { return NotFound(); }  

            Console.WriteLine("USER IS AUTHETICATED: " + newCoin.Id);

            var coin = _repo.GetAllCoins().SingleOrDefault(c => c.Id == newCoin.Id);

            if(coin == null) { return NotFound(); }

            Console.WriteLine("COIN TRYING TO ADD IS FOUND: " + newCoin.Id);

            var newAsset = new Asset();
            newAsset.Ammount = 0;
            newAsset.Coin = coin;
            newAsset.CoinId = coin.Id;
            newAsset.User = _repo.GetUser(User.Identity.GetUserId());
            newAsset.UserId = User.Identity.GetUserId();

            _repo.AddAssetToUser(newAsset, User.Identity.GetUserId());

            _repo.SaveChanges();

            return Ok(_mapper.Map<AssetDto>(newAsset));
        }
        
        [HttpPost]
        [Route("api/{controller}/update")]
        public ActionResult<IEnumerable<AssetDto>> UpdateAsset(UpdateAssetDto updateAssetDto)
        {
            Console.WriteLine($"UPDATE ASSET: {updateAssetDto.Symbol}");

            var newAsset = _repo.GetUserAssetWithSymbol(User.Identity.GetUserId(), updateAssetDto.Symbol);
            newAsset.Ammount = updateAssetDto.Ammount;

            _repo.UpdateUserAsset(User.Identity.GetUserId(), updateAssetDto.Symbol, newAsset);
            _repo.SaveChanges();

            return Ok(_mapper.Map<AssetDto>(newAsset));
        }

        [HttpPost]
        [Route("api/{controller}/delete")]
        public ActionResult<IEnumerable<AssetDto>> DeleteAsset(UpdateAssetDto updateAssetDto)
        {
            Console.WriteLine($"DELETE ASSET: {updateAssetDto.Symbol}");

            var newAsset = _repo.RemoveAssetFromUser(updateAssetDto.Symbol, User.Identity.GetUserId());
            _repo.SaveChanges();

            return Ok(_mapper.Map<AssetDto>(newAsset));
        }
    }
}