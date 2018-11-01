using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Catalog.Domain.Core.BookAggregate;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Catalog.Service.Interfaces
{
    public interface ICatalogService : IService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(Guid bookId);
    }
}
