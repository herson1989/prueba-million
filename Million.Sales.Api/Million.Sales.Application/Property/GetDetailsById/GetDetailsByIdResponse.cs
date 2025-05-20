namespace Million.Sales.Application.Property.GetDetailsById
{
    public class GetDetailsByIdResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public Domain.Entities.Owner? Owner { get; set; }
        public List<Domain.Entities.PropertyImage> Images { get; set; } = new();
    }
}
