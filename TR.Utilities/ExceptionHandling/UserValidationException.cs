using System;

namespace TR.Utilities.ExceptionHandling
{
    public class UserValidationException : Exception
    {
        public UserValidationException()
        {
        }

        public UserValidationException(string message)
            : base(message)
        {
        }

        public UserValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
