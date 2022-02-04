namespace ApiShared;
public static class ApiSharedFuncs
{
    public const string SomethingWentWrong = "Something Went Wrong";
    public const string RequestIsNull = "Request Is Null";
    public const string WrongEndPoint = "Wrong End Point";
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
        return WrongEndPoint + message;
    }
}

