namespace csharp_webapi_example.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation prop
        public List<Book> Books { get; set; }
    }
}
