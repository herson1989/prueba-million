using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;
using Million.Sales.Domain.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Million.Sales.Infrastructure.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ILogger<SalesRepository> _logger;
        private readonly MongoSetting _settings;

        private readonly IMongoCollection<Property> _properties;
        private readonly IMongoCollection<Owner> _owners;
        private readonly IMongoCollection<PropertyImage> _images;
        private readonly IMongoCollection<PropertyTrace> _traces;

        public SalesRepository(IOptions<MongoSetting> settings, ILogger<SalesRepository> logger)
        {
            _settings = settings.Value;

            MongoClient client = new(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.Database);

            _properties = db.GetCollection<Property>("properties");
            _owners = db.GetCollection<Owner>("owners");
            _images = db.GetCollection<PropertyImage>("propertyimages");
            _traces = db.GetCollection<PropertyTrace>("propertytraces");

            _logger = logger;
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            try
            {
                var properties = await _properties.Find(_ => true).ToListAsync();
                return properties;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting properties from the database");
                throw;
            }
        }

        public async Task<Owner?> GetOwnerAsync(string propertyId)
        {
            try
            {
                var property = await _properties.Find(p => p.Id == propertyId).FirstOrDefaultAsync();

                if (property == null)
                    return null;

                var owner = await _owners.Find(o => o.Id == property.IdOwner).FirstOrDefaultAsync();

                return owner;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting owner from the database");
                throw;
            }
        }

        public async Task<List<PropertyImage>> GetImagesByPropertyIdAsync(string propertyId)
        {
            try
            {
                var images = await _images.Find(i => i.IdProperty == propertyId).ToListAsync();

                return images;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting images for property {PropertyId}", propertyId);
                throw;
            }
        }
    }
}
