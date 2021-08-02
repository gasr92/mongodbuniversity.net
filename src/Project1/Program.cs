using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {

            var connString = "mongodb+srv://m220student:<m220password>@mflix.5nnhc.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            var client = new MongoClient(connString);
            var db = client.GetDatabase("sample_flix");
            var collection = db.GetCollection<BsonDocument>("movies");


            var result = collection.Find(new BsonDocument())
                           .SortByDescending(m => m["runtime"])
                           .Limit(10)
                           .ToList();

            Console.WriteLine(result);
        }
    }
}
