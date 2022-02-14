namespace Games.Data;

public static class TicTacToeConfig
{
    public static void AddTicTacToeDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<TicTacToeDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
            {
                config.MigrationsAssembly("Games.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<TicTacToeDbContext>, TicTacToeDbContextFactory>();
    }
}