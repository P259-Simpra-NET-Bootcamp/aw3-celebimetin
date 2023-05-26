namespace WebApi.Schemas
{
    public class CategoryRequest
    {
        public CategoryRequest()
        {
            Products = new List<ProductRequest>();
        }
        public string Name { get; set; }
        public List<ProductRequest> Products { get; set; }
    }
}