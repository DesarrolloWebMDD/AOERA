using System;

namespace Infrastructure.CrossCutting.CustomExections
{
    public class ControlledException : Exception
    {
        public ControlledException(string message)
            : base(message)
        {
        }

        public ControlledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}