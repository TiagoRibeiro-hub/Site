using Games.Core;
using Games.Data;
namespace Games.Web.Services;
public static class DbServices
{
    public static void AddDbServices(this IServiceCollection services)
    {
        services.AddRegisteredPlayersDbContext();
        services.AddTicTacToeDbContext();
        services.AddChessDbContext();
        services.AddRepositorys();
    }
}
