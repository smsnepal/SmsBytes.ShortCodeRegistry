using System;

namespace SmsBytes.ShortCodeRegistry.Business.Exceptions
{
    public class ApplicationNotFoundException : Exception
    {
        public ApplicationNotFoundException() : base("Application not found")
        {
        }
    }
}
