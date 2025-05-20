namespace Million.Sales.Application.Property.GetAll
{
    public class GetAllPropertiesQueryResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<Domain.Entities.Property> Properties { get; set; } = new();
    }
}
