using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Catalog.Domain.Interfaces;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

using Catalog.Domain.Core.BookAggregate;

namespace Catalog.Service
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Service : StatelessService
    {
        private IBookRepository _bookRepository;

        public Service(StatelessServiceContext context,
                            IBookRepository bookRepository)
            : base(context)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetById(Guid bookId)
        {
            return await _bookRepository.GetByIdAsync(bookId);
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        //protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        //{
        //    return this.CreateServiceRemotingInstanceListeners();
        //}

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetAllAsync();
            } catch { 

            }
        }
    }
}
