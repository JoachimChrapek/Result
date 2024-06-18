namespace FazApp.Result;

public class Error
{
    public ErrorType Type { get; }
    public string Code { get; }
    public string Description { get; }

    public Error(ErrorType type, string code, string description)
    {
        Type = type;
        Code = code;
        Description = description;
    }
}