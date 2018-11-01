using System;

namespace Catalog.Domain.Core.BookAggregate
{
    [Serializable]
    public class Publisher
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}