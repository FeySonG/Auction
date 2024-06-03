namespace Auction.Domain.Result
{
    /// <summary>
    /// Represents a result that can hold a value or an error.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class Result<TValue> : Result
    {
        public TValue? Value { get; set; } // The value of the result

        internal Result()
        {
            Value = default;  // Initializes a new instance of the Result<TValue> class
        }
        internal Result(TValue value)
        {
            Value = value;    // Initializes a new instance of the Result<TValue> class with a value
        }
        internal Result(Error error)
        {
            Value = default;   // Initializes a new instance of the Result < TValue > class with an error
            Error = error;
        }

        public static implicit operator Result<TValue>(TValue value) => new(value);  // Implicitly converts a value to a successful result
        public static implicit operator Result<TValue>(Error error) => new(error);  // Implicitly converts an error to a failed result
    }
}
