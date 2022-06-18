using csharp_webapi_example.Data;
using csharp_webapi_example.Data.Models;
using csharp_webapi_example.ViewModels;

namespace csharp_webapi_example.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
