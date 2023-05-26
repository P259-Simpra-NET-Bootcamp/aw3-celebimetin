namespace WebApi.Schemas
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}