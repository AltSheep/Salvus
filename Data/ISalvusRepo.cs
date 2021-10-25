using Microsoft.AspNetCore.Identity;
using Salvus.Models;
using System.Collections;
using System.Collections.Generic;

namespace Salvus.Data
{
    public interface ISalvusRepo
    {
        IEnumerable<Asset> GetUserAssets(string userId);

        Asset GetUserAsset(string userId, int assetId);

        Asset GetUserAssetWithSymbol(string userId, string symbol);

        public Asset GetUserAssetWithCoinSymbol(string userId, string assetSymbol);

        Asset AddAssetToUser(Asset asset, string userId);

        IEnumerable<Coin> GetAllCoins();

        Asset UpdateUserAsset(string userId, string assetSymbol, Asset asset);

        Asset RemoveAssetFromUser(string assetSymbol, string userId);

        int GetAssetValue(Asset asset);

        bool SaveChanges();

        IdentityUser GetUser(string userId);

    }
}