using AutoMapper;
using Salvus.Dtos;
using Salvus.Models;

namespace Salvus.Profiles
{
    public class SalvusProfile : Profile
    {
        public SalvusProfile()
        {
            CreateMap<Asset, AssetDto>();
            CreateMap<AssetDto, Asset>();
            CreateMap<Coin, CoinDto>();
            
        }
    }
}