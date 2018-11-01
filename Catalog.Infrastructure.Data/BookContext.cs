using MongoDB.Driver;

using Catalog.Domain.Core.BookAggregate;

namespace Catalog.Infrastructure.Data
{
    public class BookContext
    {
        private readonly IMongoDatabase _database;

        public BookContext()
        {
            string connectionString = "mongodb://localhost:27017/Store";

            MongoUrlBuilder urlBuilder = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);

            _database = client.GetDatabase(urlBuilder.DatabaseName);
        }

        public IMongoCollection<Book> Books
        {
            get
            {
                return _database.GetCollection<Book>("Books");
            }
        }
    }
}
