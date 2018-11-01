using Catalog.Domain.Core.BookAggregate;
using Catalog.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository()
        {
            _bookContext = new BookContext();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var builder = new FilterDefinitionBuilder<Book>();
            var filter = builder.Empty;

            return await _bookContext.Books.Find(filter).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid bookId)
        {
            var builder = new FilterDefinitionBuilder<Book>();
            var filter = Builders<Book>.Filter.Eq("Id", bookId);

            return await _bookContext.Books.Find(filter).FirstOrDefaultAsync();
        }

        public async Task SaveBook(Book book)
        {
            await _bookContext.Books.InsertOneAsync(book);
        }
    }
}
