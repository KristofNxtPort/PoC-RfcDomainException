using System;

namespace PoC_RfcDomainException.ApiHost.Models.Responses
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}