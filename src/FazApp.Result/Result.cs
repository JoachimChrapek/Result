namespace FazApp.Result;

public class Result : BaseResult
{
    private Result() : base()
    {
    }

    private Result(Error error) : base(error)
    {
    }

    private Result(List<Error> errors) : base(errors)
    {
    }

    public static implicit operator Result(Error error)
    {
        return new Result(error);
    }
    
    public static implicit operator Result(List<Error> errors)
    {
        return new Result(errors);
    }

    public static Result Success => new ();
    
    public void Switch(Action onValue, Action<List<Error>> onError)
    {
        if (IsError)
        {
            onError(Errors);
            return;
        }

        onValue();
    }
    
    public async Task SwitchAsync(Func<Task> onValue, Func<List<Error>, Task> onError)
    {
        if (IsError)
        {
            await onError(Errors);
            return;
        }

        await onValue();
    }
    
    public TResult Match<TResult>(Func<TResult> onValue, Func<List<Error>, TResult> onError)
    {
        if (IsError)
        {
            return onError(Errors);
        }

        return onValue();
    }
    
    public async Task<TResult> MatchAsync<TResult>(Func<Task<TResult>> onValue, Func<List<Error>, Task<TResult>> onError)
    {
        if (IsError)
        {
            return await onError(Errors);
        }

        return await onValue();
    }
    
    public static Result<TValue> From<TValue>(TValue value)
    {
        return value;
    }
}