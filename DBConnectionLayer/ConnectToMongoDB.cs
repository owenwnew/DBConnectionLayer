using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Net.Http;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DBConnectionLayer
{
    public class ConnectToMongoDB
    {
        static IMongoClient _client;
        static IMongoDatabase _dataBase;
        
        public void MongoDBConnection()
        {

            _client = new MongoClient();
            _dataBase = _client.GetDatabase("test");
            
            
        }


        public void insertDocumentToDB(BsonDocument Document, string collectionName)
        {

            if(Document != null)
            {

                var collection = _dataBase.GetCollection<BsonDocument>(collectionName);

                collection.InsertOneAsync(Document);

            }
        }

        public void insertTestJson()
        {
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                        {
                            new BsonDocument
                            {
                                { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                                { "grade", "A" },
                                { "score", 11 }
                            },
                            new BsonDocument
                            {
                                { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                                { "grade", "B" },
                                { "score", 17 }
                            }
                        }
                 },
                 { "name", "Vella" },
                 { "restaurant_id", "41704620" }
           };

            var collection = _dataBase.GetCollection<BsonDocument>("testOrders");

            collection.InsertOneAsync(document);

        }

        public void findInsertedDocument()
        {
            var collection = _dataBase.GetCollection<BsonDocument>("testOrders");
            var filter = new BsonDocument();
            var count = 0;

            //using (var cursor = await collection.FindAsync(filter))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        var batch = cursor.Current;
            //        foreach (var document in batch)
            //            count++;
            //    }

            //}
        }

        

        //async Task<int> accessTheDBAsync()
        //{


        //}
        //async Task
    }
}
