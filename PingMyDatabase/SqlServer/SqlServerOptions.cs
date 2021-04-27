using CommandLine;

namespace PingMyDatabase.SqlServer
{
    internal class SqlServerOptions : IOptions
    {
        [Option('c', "connection-string", Required = true, HelpText = "Provide the database connection string.")]
        public string ConnectionString { get; set; }
    }
}
