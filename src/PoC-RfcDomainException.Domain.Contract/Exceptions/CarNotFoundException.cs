using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using NxtPort.Lib.Exceptions;

namespace PoC_RfcDomainException.Domain.Contract.Exceptions
{
    [Serializable]
    public class CarNotFoundException : NxtPortHttpException
    {
        public CarNotFoundException(string detail) : base(detail)
        {
        }

        [ExcludeFromCodeCoverage]
        protected CarNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override int StatusCode { get; } = 404;
        public override string Instance { get; } = "urn:nxtport:poc:rfc-domain-exception:car-not-found";
    }
}