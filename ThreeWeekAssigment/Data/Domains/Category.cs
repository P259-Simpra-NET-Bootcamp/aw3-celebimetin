namespace Data.Domains
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}