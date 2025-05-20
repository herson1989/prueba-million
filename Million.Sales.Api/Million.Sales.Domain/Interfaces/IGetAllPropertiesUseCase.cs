using Million.Sales.Domain.Entities;

namespace Million.Sales.Domain.Interfaces
{
    public interface IGetAllPropertiesUseCase
    {
        Task<List<Property>> Execute();
    }
}
