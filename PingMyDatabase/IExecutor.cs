namespace PingMyDatabase
{
    internal interface IExecutor
    {
        Databases Name { get; }
        void Execute(IOptions options);
    }
}
