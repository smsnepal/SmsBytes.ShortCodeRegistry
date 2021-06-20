using System;

namespace SmsBytes.ShortCodeRegistry.Business.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string message) : base(message)
        {
        }
    }
}
