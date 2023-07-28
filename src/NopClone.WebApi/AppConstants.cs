namespace NopClone.WebApi
{
    public static class AppConstants
    {
        public const string EFCoreProvider = nameof(EFCoreProvider);
        public readonly struct EFCoreProviders
        {
            public const string SqlServer = nameof(SqlServer);
            public const string Sqlite = nameof(Sqlite);
            public const string InMemory = nameof(InMemory);
        }
    }
}
