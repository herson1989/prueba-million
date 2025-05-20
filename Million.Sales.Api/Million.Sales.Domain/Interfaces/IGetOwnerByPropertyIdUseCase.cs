using Million.Sales.Domain.Entities;

namespace Million.Sales.Domain.Interfaces
{
    public interface IGetOwnerByPropertyIdUseCase
    {
        Task<Owner?> Execute(string propertyId);
    }
}
