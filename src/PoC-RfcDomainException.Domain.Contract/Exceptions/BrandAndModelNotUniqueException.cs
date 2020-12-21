using System;
using System.Runtime.Serialization;
using NxtPort.Lib.Exceptions;

namespace PoC_RfcDomainException.Domain.Contract.Exceptions
{
    [Serializable]
    public class BrandAndModelNotUniqueException : NxtPortException
    {
        public BrandAndModelNotUniqueException(string detail) : base(detail)
        {
        }

        protected BrandAndModelNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Title { get; } = "Brand and Model should be unique.";
        public override string Instance { get; } = "urn:nxtport:poc:rfc-domain-exception:brand-and-model-not-unique";
    }
}