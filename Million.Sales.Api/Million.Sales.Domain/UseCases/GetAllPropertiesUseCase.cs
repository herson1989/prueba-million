using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;

namespace Million.Sales.Domain.UseCases
{
    public class GetAllPropertiesUseCase : IGetAllPropertiesUseCase
    {
        private readonly ISalesRepository _salesRepository;

        public GetAllPropertiesUseCase(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<List<Property>> Execute()
        {
            return await _salesRepository.GetAllPropertiesAsync();
        }
    }
}
