using System;

namespace Tennis.Logic.Model
{
    public class InvalidNumberOfSetsException : Exception
    {
        public InvalidNumberOfSetsException(string message) : base(message)
        {
        }
    }
}