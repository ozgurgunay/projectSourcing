using ESourcing.Sourcing.Data.Interface;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            //burada mongoDb ye erismek icin client da ve database de mongoDb nin bilgileri getiriyorum Settings in ConnectionString ve DatabaseName ini mapp liyoruz.


            Auctions = database.GetCollection<Auction>(nameof(Auction));
            //database in GetCollection methodu ile Auction a erisiyorum ve buna nameof ile collection ın ismini verdim.
            Bids = database.GetCollection<Bid>(nameof(Bid));

            SourcingContextSeed.SeedData(Auctions);
        }

        public IMongoCollection<Auction> Auctions { get; }

        public IMongoCollection<Bid> Bids { get; }
    }
}
