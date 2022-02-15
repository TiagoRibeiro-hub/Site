#nullable disable
namespace Games.Infrastructure.RepositoryService;

public static class RepositoryExtension
{
    public static int GetEntityKeyValue<TEntity>(this TEntity entity) where TEntity : class
    {
        var key = entity.GetType().GetProperty("Id").GetValue(entity, null);
        if (key == null)
        {
            throw new Exception();
        }
        return (int)key;
    }
}