namespace Games.Data;

public class TicTacToeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
{
    public TicTacToeDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<TicTacToeDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
        {
            config.MigrationsAssembly("Games.Data");
        });

        return new TicTacToeDbContext(builder.Options);
    }
}
