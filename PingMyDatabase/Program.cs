using CommandLine;
using PingMyDatabase;
using PingMyDatabase.MongoDb;
using PingMyDatabase.SqlServer;

namespace DbConnectionTester
{
    class Program
    {

        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<SqlServerOptions, MongoDbOptions>(args)
                .MapResult(
                    (SqlServerOptions opts) =>
                    {
                        var client = Client.GetExecutor(Databases.SqlServer);
                        client?.Execute(opts);
                        return (int)ExitCode.Success;
                    },
                    (MongoDbOptions opts) =>
                    {
                        var client = Client.GetExecutor(Databases.MongoDb);
                        client?.Execute(opts);
                        return (int)ExitCode.Success;
                    },
                    errs =>
                    {
                        ConsoleHelper.RenderErrors(errs);
                        return (int)ExitCode.Failure;
                    });
        }
    }
}
