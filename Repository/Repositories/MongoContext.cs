using MongoDB.Driver;

namespace Data.Repositories
{
    public class MongoContext : IMongoContext
    {
        public IMongoDatabase MongoDataBase { get; }

        public MongoContext(string connectionString, string dataBase)
        {
            var clientMongo = new MongoClient(connectionString);
            MongoDataBase = clientMongo.GetDatabase(dataBase);
        }
    }

    public interface IMongoContext
    {
        public IMongoDatabase MongoDataBase { get; }
    }
}
