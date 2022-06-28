namespace csharp_webapi_example.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        //Nav props
        public  int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
