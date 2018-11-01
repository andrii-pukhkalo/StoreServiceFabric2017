using System;

namespace Catalog.Domain.Core.BookAggregate
{
    [Serializable]
    public class Price
    {
        public double Amount { get; private set; }
        public string Currency { get; private set; }
    }
}