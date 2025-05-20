using Million.Sales.Domain.Entities;

namespace Million.Sales.Domain.Interfaces
{
    public interface IGetImagesByPropertyIdUseCase
    {
        Task<List<PropertyImage>> Execute(string propertyId);
    }
}
