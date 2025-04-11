namespace FakeStore.Domain.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public float publicPrice { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
    }
}
