namespace ApiShared;
public class ApiSharedFuncs
{
    public const string SomethingWentWrong = "Something Went Wrong";
    public static HashSet<string> GetListErrord(Exception ex)
    {
        HashSet<string> errors = new();
        foreach (var error in ex.Data)
        {
            errors.Add(error.ToString());
        }

        return errors;
    }
}

