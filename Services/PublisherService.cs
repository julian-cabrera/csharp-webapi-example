using csharp_webapi_example.Data;
using csharp_webapi_example.Data.Models;
using csharp_webapi_example.ViewModels;

namespace csharp_webapi_example.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
