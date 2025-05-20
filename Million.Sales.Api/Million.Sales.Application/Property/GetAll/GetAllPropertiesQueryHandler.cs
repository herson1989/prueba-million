using MediatR;
using Million.Sales.Domain.Interfaces;

namespace Million.Sales.Application.Property.GetAll
{
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, GetAllPropertiesQueryResponse>
    {
        private readonly IGetAllPropertiesUseCase _getAllPropertiesUseCase;

        public GetAllPropertiesQueryHandler(IGetAllPropertiesUseCase getAllPropertiesUseCase)
        {
            _getAllPropertiesUseCase = getAllPropertiesUseCase;
        }

        public async Task<GetAllPropertiesQueryResponse> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Property> properties = await _getAllPropertiesUseCase.Execute();

            return new GetAllPropertiesQueryResponse
            {
                Success = true,
                Message = properties == null || properties.Count == 0 ? "No properties found." : "Properties retrieved successfully.",
                Properties = properties ?? []
            };
        }
    }
}
