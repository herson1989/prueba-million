using MediatR;
using Million.Sales.Application.Property.GetAll;
using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;

namespace Million.Sales.Application.Property.GetDetailsById
{
    public class GetDetailsByIdQueryHandler : IRequestHandler<GetDetailsByIdQuery, GetDetailsByIdResponse>
    {
        private readonly IGetOwnerByPropertyIdUseCase _getOwnerByPropertyIdUseCase;
        private readonly IGetImagesByPropertyIdUseCase _getImagesByPropertyIdUseCase;

        public GetDetailsByIdQueryHandler(IGetOwnerByPropertyIdUseCase getOwnerByPropertyIdUseCase, IGetImagesByPropertyIdUseCase getImagesByPropertyIdUseCase)
        {
            _getOwnerByPropertyIdUseCase = getOwnerByPropertyIdUseCase;
            _getImagesByPropertyIdUseCase = getImagesByPropertyIdUseCase;
        }

        public async Task<GetDetailsByIdResponse> Handle(GetDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var ownerTask = _getOwnerByPropertyIdUseCase.Execute(request.PropertyId);
            var imagesTask = _getImagesByPropertyIdUseCase.Execute(request.PropertyId);

            await Task.WhenAll(ownerTask, imagesTask);

            var owner = await ownerTask;
            var images = await imagesTask ?? [];

            bool hasData = owner != null || images.Count != 0;

            return new GetDetailsByIdResponse
            {
                Success = true,
                Message = hasData ? "Details retrieved successfully." : "No details found for the specified property.",
                Owner = owner,
                Images = images
            };
        }
    }
}
