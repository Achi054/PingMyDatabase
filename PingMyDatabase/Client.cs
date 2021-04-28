using System;
using System.Collections.Generic;
using System.Linq;

namespace PingMyDatabase
{
    internal static class Client
    {
        static IDictionary<Databases, IExecutor> clients { get; }

        static Client()
        {
            clients = typeof(Client).Assembly.DefinedTypes
                .Where(x =>
                    x.IsClass &&
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    typeof(IExecutor).IsAssignableFrom(x))
                .Select(x => (IExecutor)Activator.CreateInstance(x))
                .Select(x => new KeyValuePair<Databases, IExecutor>(x.Name, x))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public static IExecutor GetExecutor(Databases database)
        {
            if (clients.TryGetValue(database, out IExecutor executor))
                return executor;

            Console.WriteLine($"Sorry, working in progress, {database} executor!");
            return null;
        }
    }
}
