namespace ApiShared;
public class Error
{
    public Error()
    {

    }

    public Error(List<ErrorModel> errors)
    {
        Errors = errors;
    }

    public List<ErrorModel> Errors { get; set; } = new();

}

public class ErrorModel
{
    public string FieldName { get; set; }
    public string Message { get; set; }
}