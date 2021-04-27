using System;
using System.Linq;
using MongoDB.Driver;

namespace PingMyDatabase.MongoDb
{
    internal class Executor : IExecutor
    {
        public Databases Name { get; } = Databases.MongoDb;

        public void Execute(IOptions options)
        {
            try
            {
                var client = new MongoClient(options.ConnectionString);

                var databases = client.ListDatabases().ToList().Select(db => db.GetValue("name").AsString);

                if (databases.Any())
                {
                    var mongoOptions = options as MongoDbOptions;
                    if (!string.IsNullOrWhiteSpace(mongoOptions.DatabaseName) && databases.Contains(mongoOptions.DatabaseName))
                        Console.WriteLine("Ping to successful. You are good to Go!");

                    Console.WriteLine("Ping unsuccessful. Database does not exist!");
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.RenderExceptionDetails(ex);
            }
        }
    }
}
