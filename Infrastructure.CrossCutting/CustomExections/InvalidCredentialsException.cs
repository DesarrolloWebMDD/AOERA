using System;

namespace Infrastructure.CrossCutting.CustomExections
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message)
            : base(message)
        {
        }
    }
}