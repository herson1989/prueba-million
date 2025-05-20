using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;

namespace Million.Sales.Domain.UseCases
{
    public class GetImagesByPropertyIdUseCase : IGetImagesByPropertyIdUseCase
    {
        private readonly ISalesRepository _salesRepository;
        public GetImagesByPropertyIdUseCase(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }
        public async Task<List<PropertyImage>> Execute(string propertyId)
        {
            return await _salesRepository.GetImagesByPropertyIdAsync(propertyId);
        }
    }
}
