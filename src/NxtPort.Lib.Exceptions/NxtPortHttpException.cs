using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NxtPort.Lib.Exceptions
{
    [Serializable]
    public abstract class NxtPortHttpException : Exception
    {
        protected NxtPortHttpException(string detail)
        {
            Detail = detail;
        }

        [ExcludeFromCodeCoverage]
        protected NxtPortHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Detail { get; private set; }

        public abstract int StatusCode { get; set; }
        public abstract string Instance { get; set; }
    }
}