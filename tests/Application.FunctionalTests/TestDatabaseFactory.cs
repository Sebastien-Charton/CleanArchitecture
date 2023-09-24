namespace CleanArchitecture.Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
#if (UsePostgreSQL)
    #if DEBUG
        var database = new PostgreSqlTestDatabase();
    #else
        var database = new TestcontainersTestDatabase();
    #endif
#else
        SqliteTestDatabase database = new();
#endif

        await database.InitialiseAsync();

        return database;
    }
}
