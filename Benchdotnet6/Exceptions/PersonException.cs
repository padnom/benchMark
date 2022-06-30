using System.Runtime.Serialization;

namespace Benchdotnet6.Exceptions
{
    [Serializable]
    internal class PersonException : Exception
    {
        public PersonException()
        {
        }

        public PersonException(string? message) : base(message)
        {
        }

        public PersonException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PersonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}