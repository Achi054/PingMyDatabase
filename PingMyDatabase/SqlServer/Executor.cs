using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PingMyDatabase.SqlServer
{
    internal class Executor : IExecutor
    {
        private const string initialCatalog = "Initial Catalog";

        public Databases Name { get; } = Databases.SqlServer;

        public void Execute(IOptions options)
        {
            var propertyStack = new Stack<string>(options.ConnectionString.Split(';'));
            propertyStack.Pop();
            var configs = propertyStack
                .Select(x =>
                {
                    var properties = x.Split('=');
                    return (key: properties[0].Trim(), value: properties[1].Trim());
                });

            using var sqlConnection = new SqlConnection(options.ConnectionString.Trim());

            try
            {
                var sb = new StringBuilder("SELECT COUNT(1) FROM sys.databases");

                if (configs.Any(x => x.key == initialCatalog))
                {
                    sb.Append($" WHERE name = '{configs.First(x => x.key == initialCatalog).value}'");
                }

                sb.Append(";");

                var sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);

                sqlCommand.Connection.Open();

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                Console.WriteLine("Ping successful. You are good to Go!");
            }
            catch (SqlException ex)
            {
                ConsoleHelper.RenderExceptionDetails(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
