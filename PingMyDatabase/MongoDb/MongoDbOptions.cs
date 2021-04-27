using CommandLine;

namespace PingMyDatabase.MongoDb
{
    internal class MongoDbOptions : IOptions
    {
        [Option('c', "connection-string", Required = true, HelpText = "Provide the database connection string.")]
        public string ConnectionString { get; set; }

        [Option('n', "database-name", Required = true, HelpText = "Provide the database name.")]
        public string DatabaseName { get; set; }
    }
}
