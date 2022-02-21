namespace Games.Data;

public class RegisteredPlayersDbContextFactory : IDesignTimeDbContextFactory<RegisteredPlayersDbContext>
{
    public RegisteredPlayersDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<RegisteredPlayersDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("RegisteredPlayersConnection"), config =>
        {
            config.MigrationsAssembly("Games.Data");
        });

        return new RegisteredPlayersDbContext(builder.Options);
    }
}
