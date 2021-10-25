using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Salvus.Models;

namespace Salvus.Migrations
{
    public partial class PopulateCoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var coinList = JsonSerializer.Deserialize<List<Coin>>(File.ReadAllText("Data/CoinsList.json"));

            foreach(var coin in coinList)
            {
                if(coin.Symbol.Length > 16) { continue; }

                migrationBuilder.Sql($"INSERT INTO Coins (Id, Symbol, Name)VALUES ('{coin.Id}', '{coin.Symbol}', '{coin.Name}');");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
