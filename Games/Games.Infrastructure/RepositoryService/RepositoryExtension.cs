using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Games.Infrastructure.RepositoryService;

public static class RepositoryExtension
{
    public static int GetEntityKeyValue<TEntity>(this TEntity entity) where TEntity : class
    {
        int res = 0;
        PropertyInfo key = typeof(TEntity).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
        if (key != null)
        {
            res = (int)key.GetValue(entity, null);
            if (res > 0)
            {
                return res;
            }
        }
        throw new Exception();
    }
}