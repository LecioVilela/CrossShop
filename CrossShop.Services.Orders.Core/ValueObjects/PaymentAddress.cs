using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossShop.Services.Orders.Core.ValueObjects
{
    public class PaymentAddress
    {
        public PaymentAddress(string street, string numbeer, string city, string state, string zipCode)
        {
            Street = street;
            Numbeer = numbeer;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Numbeer { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is PaymentAddress address &&
                   Street == address.Street &&
                   Numbeer == address.Numbeer &&
                   City == address.City &&
                   State == address.State &&
                   ZipCode == address.ZipCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Numbeer, City, State, ZipCode);
        }
    }
}