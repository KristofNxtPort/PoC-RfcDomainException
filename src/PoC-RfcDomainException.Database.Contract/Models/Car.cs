﻿using System;

namespace PoC_RfcDomainException.Database.Contract.Models
{
    public class Car
    {
        public Guid Id { get; internal set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}