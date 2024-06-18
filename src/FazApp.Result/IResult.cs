namespace FazApp.Result;

public interface IResult
{
    bool IsError { get; }
    List<Error> Errors { get; }
}