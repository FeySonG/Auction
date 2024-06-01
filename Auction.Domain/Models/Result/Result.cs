namespace Auction.Domain.Models.Result
{
    /// <summary>
    /// Base class for result objects.
    /// </summary>
    public abstract class Result
    {
       
        public Error? Error { get; set; }  // Error associated with the result, if any

        public bool IsSuccess => Error is null; // Indicates whether the result is successful
        
        public bool IsFailure => Error is not null; // Indicates whether the result is a failure
        
        public static Result<TValue> Ok<TValue>() => new(); // Creates a successful result with no value
       
        public static Result<TValue> Ok<TValue>(TValue value) => new(value);  // Creates a successful result with a value

        public static Result<TValue> Fail<TValue>(Error error) => new(error); // Creates a failed result with an error

        public static Result<TValue> Fail<TValue>(string errorCode, string? message)
            => new(new Error(errorCode, message)); // Creates a failed result with an error code and message
    }
}
