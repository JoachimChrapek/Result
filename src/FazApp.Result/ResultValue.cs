namespace FazApp.Result;

public class Result<TValue> : BaseResult
{
    private readonly TValue? _value;

    public TValue Value => _value!;

    private Result(TValue value) : base()
    {
        _value = value;
    }
    
    private Result(Error error) : base(error)
    {
    }

    private Result(List<Error> errors) : base(errors)
    {
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }
    
    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }
    
    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return new Result<TValue>(errors);
    }
    
    public void Switch(Action<TValue> onValue, Action<List<Error>> onError)
    {
        if (IsError)
        {
            onError(Errors);
            return;
        }

        onValue(Value);
    }
    
    public async Task SwitchAsync(Func<TValue, Task> onValue, Func<List<Error>, Task> onError)
    {
        if (IsError)
        {
            await onError(Errors);
            return;
        }

        await onValue(Value);
    }
    
    public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<List<Error>, TResult> onError)
    {
        if (IsError)
        {
            return onError(Errors);
        }

        return onValue(Value);
    }
    
    public async Task<TResult> MatchAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<List<Error>, Task<TResult>> onError)
    {
        if (IsError)
        {
            return await onError(Errors);
        }

        return await onValue(Value);
    }

    public static Result<TValue> From(TValue value)
    {
        return value;
    }
}