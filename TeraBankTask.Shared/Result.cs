using TeraBankTask.Shared.Interfaces;

namespace TeraBankTask.Shared;

public class Result<T> : IResult<T>
{
    public List<string> Messages { get; set; } = new List<string>();
    public bool Succeeded { get; set; }
    public bool Warninged { get; set; }
    public T Data { get; set; }
    public Exception Exception { get; set; }
    public int Code { get; set; }

    #region Success Methods 

    public static Result<T> Success()
    {
        return new Result<T>
        {
            Succeeded = true
        };
    }

    public static Result<T> Success(string message)
    {
        return new Result<T>
        {
            Succeeded = true ,
            Messages = new List<string> { message }
        };
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>
        {
            Succeeded = true ,
            Data = data
        };
    }

    public static Result<T> Success(T data , string message)
    {
        return new Result<T>
        {
            Succeeded = true ,
            Messages = new List<string> { message } ,
            Data = data
        };
    }

    public static Result<T> Warning(string messages)
    {
        return new Result<T>
        {
            Warninged = true ,
            Succeeded = false ,
            Code = 1 ,
            Messages = new List<string> { messages }
        };
    }
    #endregion

    #region Failure Methods 

    public static Result<T> Failure()
    {
        return new Result<T>
        {
            Succeeded = false
        };
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>
        {
            Succeeded = false ,
            Messages = new List<string> { message }
        };
    }

    public static Result<T> Failure(T data)
    {
        return new Result<T>
        {
            Succeeded = false ,
            Data = data
        };
    }

    public static Result<T> Failure(Exception exception)
    {
        return new Result<T>
        {
            Succeeded = false ,
            Exception = exception
        };
    }

    #endregion
}
