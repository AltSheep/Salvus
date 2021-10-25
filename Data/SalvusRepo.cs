using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Salvus.Models;

namespace Salvus.Data
{
    public class SalvusRepo : ISalvusRepo
    {
        private readonly SalvusContextDb _context;

        public SalvusRepo(SalvusContextDb context)
        {
            _context = context;
        }

        public Asset AddAssetToUser(Asset asset, string userId)
        {
            // check if user already has the asset trying to add in there portfolio
            var usersAssets = GetUserAssets(userId);
            var foundAsset = usersAssets.SingleOrDefault(a => a.Coin.Id == asset.Coin.Id);
            if(foundAsset != null) 
            { 
                Console.WriteLine($"USER<{userId}> ALREADY HAS <{asset.Coin.Name}> IN THERE PORTFOLIO");
                return null;
            }

            _context.Assets.Add(asset);
            return asset;
        }

        public IEnumerable<Coin> GetAllCoins()
        {
            return _context.Coins;
        }

        public int GetAssetValue(Asset asset)
        {
            // TODO impment requests
            return 0;
        }

        public Asset GetUserAsset(string userId, int assetId)
        {
            return _context.Assets.SingleOrDefault(a => a.User.Id == userId && a.Id == assetId);
        }

        public Asset GetUserAssetWithSymbol(string userId, string symbol)
        {
            return _context.Assets.Include(a => a.Coin).SingleOrDefault(a => a.User.Id == userId && a.Coin.Symbol == symbol);
        }

        public Asset GetUserAssetWithCoinSymbol(string userId, string assetSymbol)
        {
            return _context.Assets.Include(a => a.Coin).SingleOrDefault(a => a.User.Id == userId && a.Coin.Symbol == assetSymbol);
        }

        public IEnumerable<Asset> GetUserAssets(string userId)
        {
            return _context.Assets.Include(a => a.Coin).Where(a => a.User.Id == userId);
        }

        public Asset RemoveAssetFromUser(string assetSymbol, string userId)
        {
            var asset = GetUserAssetWithCoinSymbol(userId, assetSymbol);

            if(asset == null)
            {
                Console.WriteLine($"USER<{userId}> HAS NO <{assetSymbol}>");
                return null;
            }

            _context.Assets.Remove(asset);
            return asset;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Asset UpdateUserAsset(string userId, string assetSymbol, Asset asset)
        {
            var assetInDb = GetUserAssetWithCoinSymbol(userId, assetSymbol);

            if(assetInDb == null)
            {
                Console.WriteLine($"NO ASSET <{asset.Coin.Name}> FOR <{userId}> TO MODIFY");
                return null;
            }

            assetInDb = asset;
            
            return asset;
        }

        public IdentityUser GetUser(string userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}