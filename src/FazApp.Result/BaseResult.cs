namespace FazApp.Result;

public abstract class BaseResult : IResult
{
    public bool IsError { get; }
    public List<Error> Errors { get; }
    
    protected BaseResult()
    {
        Errors = new List<Error>();
        IsError = false;
    }

    protected BaseResult(Error error)
    {
        Errors = new List<Error> {
            error
        };

        IsError = true;
    }

    protected BaseResult(List<Error> errors)
    {
        Errors = errors;
        IsError = true;
    }
}