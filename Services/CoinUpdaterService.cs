using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Salvus.Data;
using Salvus.Models;

namespace Salvus.Services
{
    public class CoinUpdaterService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private ISalvusRepo _repo;

        private Timer _timer;

        public CoinUpdaterService(IServiceScopeFactory scopeFactory)
        {
            
            _scopeFactory = scopeFactory;

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateCoins, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void UpdateCoins(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                _repo = scope.ServiceProvider.GetRequiredService<ISalvusRepo>();

                // get all coins that need to be updated
                var coins = _repo.GetAllCoins();

                // build url to get current coin data
                String coinList = "";
                int c = 0;
                foreach(Coin coin in coins)
                {
                    coinList += $"{coin.Id}%2C";
                    c++;
                    if(c > 300) { break; }
                }
                coinList = coinList.Substring(0, coinList.Length - 4);

                Console.WriteLine(coinList);

                string url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids={coinList}&per_page=1&page=1&sparkline=false&price_change_percentage=24h%2C7d";

                Console.WriteLine(url);
                using (StreamWriter writer = new StreamWriter("./url.txt"))  
                {  
                    writer.WriteLine(url);  
                }  

                // update database with new coin data
            }


        }
    }
}