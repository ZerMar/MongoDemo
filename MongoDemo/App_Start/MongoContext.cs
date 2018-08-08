using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MongoDemo.App_Start
{
    public class MongoContext
    {
        MongoClient _client;
        MongoServer _server;
        public MongoDatabase _database;
        public MongoContext() //constructor   
        {
            // Reading credentials from Web.config file   
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"]; //CarDatabase  
           // var MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];   
           // var MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];   
            var MongoPort = ConfigurationManager.AppSettings["MongoPort"];  //27017  
            var MongoHost = ConfigurationManager.AppSettings["MongoHost"];  //localhost  
          
            var settings = new MongoClientSettings
            {
                  // Credentials = new[] { credential },
                  Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))//For Local
                  // Server = new MongoServerAddress(mongoUrl.ToString())
            };

            _client = new MongoClient(settings); //For local

            _server = _client.GetServer();//For Local
             _database = _server.GetDatabase(MongoDatabaseName); // For Local

        }
    }
}