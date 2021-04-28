using CommandLine;

namespace PingMyDatabase.SqlServer
{
    [Verb("mssql", HelpText = "For Microsoft sql server connection validation.")]
    internal class SqlServerOptions : IOptions
    {
        [Option('c', "connection-string", Required = true, HelpText = "Provide the database connection string.")]
        public string ConnectionString { get; set; }
    }
}
