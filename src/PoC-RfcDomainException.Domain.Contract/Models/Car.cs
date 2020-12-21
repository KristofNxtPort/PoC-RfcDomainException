using System;

namespace PoC_RfcDomainException.Domain.Contract.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}