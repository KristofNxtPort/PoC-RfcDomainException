using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NxtPort.Lib.Exceptions
{
    [Serializable]
    public abstract class NxtPortException : Exception
    {
        protected NxtPortException(string detail)
        {
            Detail = detail;
        }

        [ExcludeFromCodeCoverage]
        protected NxtPortException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Detail { get; private set; }

        public abstract string Title { get; }
        public abstract string Instance { get; }
    }
}