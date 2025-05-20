using Million.Sales.Domain.Entities;

namespace Million.Sales.Domain.Interfaces
{
    public interface ISalesRepository
    {
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Owner?> GetOwnerAsync(string propertyId);
        Task<List<PropertyImage>> GetImagesByPropertyIdAsync(string propertyId);
    }
}
