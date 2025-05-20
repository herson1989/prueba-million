using MediatR;

namespace Million.Sales.Application.Property.GetDetailsById
{
    public class GetDetailsByIdQuery : IRequest<GetDetailsByIdResponse>
    {
        public string PropertyId { get; }

        public GetDetailsByIdQuery(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
