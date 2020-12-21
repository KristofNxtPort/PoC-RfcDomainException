using System;
using System.Runtime.Serialization;

namespace PoC_RfcDomainException.Domain.Contract.Exceptions
{
    [Serializable]
    public class BrandAndModelNotUniqueException : Exception
    {
        public BrandAndModelNotUniqueException()
        {
        }

        protected BrandAndModelNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}