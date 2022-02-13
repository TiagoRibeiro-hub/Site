namespace Games.Data;

public class ChessDbContextFactory : IDesignTimeDbContextFactory<ChessDbContext>
{
    public ChessDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<ChessDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("ChessConnection"), config =>
        {
            config.MigrationsAssembly("Games.Infrastructure");
        });

        return new ChessDbContext(builder.Options);
    }
}

