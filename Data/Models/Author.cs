namespace csharp_webapi_example.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Nav props
        public List<Book_Author> Book_Author { get; set; }
    }
}
