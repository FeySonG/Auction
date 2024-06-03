namespace Auction.Domain.Result
{
    /// <summary>
    /// Represents an error with a code and an optional message.
    /// </summary>
    public class Error(string code, string? message)
    {
        public string Code { get; set; } = code; // Error code

        public string? Message { get; set; } = message;  // Error message
    }
}

