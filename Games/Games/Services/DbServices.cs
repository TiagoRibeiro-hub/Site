using Games.Data;
using Games.Infrastructure;
namespace Games.Web.Services;
public static class DbServices
{
    public static void AddDbServices(this IServiceCollection services)
    {

        services.AddTicTacToeDbContext();
        services.AddChessDbContext();
        services.AddRepository();
    }
}
