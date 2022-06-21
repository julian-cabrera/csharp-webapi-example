using csharp_webapi_example.Data;
using csharp_webapi_example.Data.Models;
using csharp_webapi_example.Data.Paging;
using csharp_webapi_example.Exceptions;
using csharp_webapi_example.ViewModels;
using System.Text.RegularExpressions;

namespace csharp_webapi_example.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("Name starts with number", publisher.Name);

            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var publishers = _context.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                            publishers = publishers.OrderByDescending(n => n.Name).ToList();
                            break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                publishers = publishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            int pageSize = 5;
            publishers = PaginatedList<Publisher>.Create(publishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return publishers; 
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int id)
        {
            var _publisherData = _context.Publishers.Where(x => x.Id == id)
                .Select(x => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(y => new BookAuthorVM()
                    {
                        BookName = y.Title,
                        BookAuthors = y.Book_Author.Select(z => z.Author.FullName).ToList()
                    }).ToList()
                })
                .FirstOrDefault();
            return _publisherData;
        }

        public void Delete(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);

            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            } else
            {
                throw new Exception($"The publisher id: {id} not exist");
            }
        }

        private bool StringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");
    }
}
