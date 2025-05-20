using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;

namespace Million.Sales.Domain.UseCases
{
    public class GetOwnerByPropertyIdUseCase : IGetOwnerByPropertyIdUseCase
    {
        private readonly ISalesRepository _salesRepository;

        public GetOwnerByPropertyIdUseCase(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<Owner?> Execute(string propertyId)
        {
            return await _salesRepository.GetOwnerAsync(propertyId);
        }
    }
}
