using ForjaDev.Domain.BackOffice.Abstract;

namespace ForjaDev.Domain.BackOffice.Commum;

public class Result<T> : Result
{
    public T Value { get;private set; }

    private Result(T value) : base()
        => Value = value;
    private Result(Error error) : base(error)
    {}
    
    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(Error error) => new Result<T>(error);

    public static implicit operator Result<T>(Error error)
        => new Result<T>(error);

}