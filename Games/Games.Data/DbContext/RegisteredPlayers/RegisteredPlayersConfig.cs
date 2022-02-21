namespace Games.Data;

public static class RegisteredPlayersConfig
{
    public static void AddRegisteredPlayersDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<RegisteredPlayersDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("RegisteredPlayersConnection"), config =>
            {
                config.MigrationsAssembly("Games.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<RegisteredPlayersDbContext>, RegisteredPlayersDbContextFactory>();
    }
}
