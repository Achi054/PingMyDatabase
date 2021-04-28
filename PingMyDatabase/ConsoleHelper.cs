using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace PingMyDatabase
{
    internal static class ConsoleHelper
    {
        public static void RenderExceptionDetails(Exception ex)
        {
            var sb = new StringBuilder("Encountered an Error!");

            sb.Append(Environment.NewLine);
            sb.AppendJoin(Environment.NewLine, $"Message: {ex.Message}");
            sb.Append(Environment.NewLine);
            if (ex.InnerException != null)
            {
                sb.AppendJoin(Environment.NewLine, ex.InnerException.Message);
            }
            sb.Append(Environment.NewLine);
            sb.AppendJoin(Environment.NewLine, "StackTrace:");
            sb.AppendJoin(Environment.NewLine, ex.StackTrace);

            Console.WriteLine(sb.ToString());
        }

        public static void RenderErrors(IEnumerable<Error> errors)
        {
            var sb = new StringBuilder("Not able to parse your inputs!");
            sb.AppendJoin(Environment.NewLine, "Error due to,");
            foreach (var error in errors)
            {
                sb.AppendJoin(Environment.NewLine, error.Tag.ToString());
            }
        }
    }
}
