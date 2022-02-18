namespace ApiShared;
public static class ApiSharedFuncs
{

    public static HashSet<string> GetListErrord(Exception ex)
    {
        HashSet<string> errors = new();
        foreach (var error in ex.Data)
        {
            errors.Add(error.ToString());
        }

        return errors;
    }

    public static string SetApisWrongEndPoint(string message)
    {
        return ApiSharedConst.WrongEndPoint + message;
    }
}
