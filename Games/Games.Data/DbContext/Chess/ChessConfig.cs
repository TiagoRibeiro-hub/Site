namespace Games.Data;

public static class ChessConfig
{
    public static void AddChessDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<ChessDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("ChessConnection"), config =>
            {
                config.MigrationsAssembly("Games.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<ChessDbContext>, ChessDbContextFactory>();
    }
}

