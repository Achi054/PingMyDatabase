using CommandLine;

namespace PingMyDatabase.MongoDb
{
    [Verb("mongodb", HelpText = "For mongodb connection validation.")]
    internal class MongoDbOptions : IOptions
    {
        [Option('c', "connection-string", Required = true, HelpText = "Provide the database connection string.")]
        public string ConnectionString { get; set; }

        [Option('n', "collection-name", Required = false, HelpText = "Provide the collection name.")]
        public string CollectionName { get; set; }
    }
}
