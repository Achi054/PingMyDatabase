using System;
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

                var mongoOptions = options as MongoDbOptions;
                var collection = client.GetDatabase(mongoOptions.CollectionName);

                if (collection is null)
                    Console.WriteLine("Ping unsuccessful. Database does not exist!");

                Console.WriteLine("Ping to successful. You are good to Go!");
            }
            catch (Exception ex)
            {
                ConsoleHelper.RenderExceptionDetails(ex);
            }
        }
    }
}
