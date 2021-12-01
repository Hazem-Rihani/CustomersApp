using CustomersApp.Api.Constants;
using CustomersApp.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

// For improvement, i prefer to have the data contexts in DAL project not in the api
namespace CustomersApp.Api.DataAccess
{
    public class CustomerDbContext
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public CustomerDbContext()
        {
            _client = new MongoClient(ConstantStings.MongoDBConnectionString);
            _server = _client.GetServer();
            _db = _server.GetDatabase(ConstantStings.DatabaseName);
        }

        public IEnumerable<Customer> Customers()
        {
            return _db.GetCollection<Customer>("Customers").FindAll();
        }


        public Customer GetCustomer(int id)
        {
            var res = Query<Customer>.EQ(p => p.Id, id);
            return _db.GetCollection<Customer>("Customers").FindOne(res);
        }

        public Customer Create(Customer p)
        {
            _db.GetCollection<Customer>("Customers").Save(p);
            return p;
        }

        public void Update(int id, Customer p)
        {
            p.Id = id;
            var res = Query<Customer>.EQ(pd => pd.Id, id);
            var operation = Update<Customer>.Replace(p);
            _db.GetCollection<Customer>("Customers").Update(res, operation);
        }
        public void Remove(int id)
        {
            var res = Query<Customer>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Customer>("Customers").Remove(res);
        }
    }
}

