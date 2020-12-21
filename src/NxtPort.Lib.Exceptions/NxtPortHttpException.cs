using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
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

        public abstract HttpStatusCode StatusCode { get; }
        public abstract string Instance { get; }
    }
}