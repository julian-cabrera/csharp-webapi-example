using csharp_webapi_example.Data;
using csharp_webapi_example.Data.Models;

namespace csharp_webapi_example.Services
{
    public class LogService
    {
        private AppDbContext _context;

        public LogService(AppDbContext context)
        {
            _context = context;
        }

        public List<Log> GetAllLogsFromDb() => _context.Logs.ToList();
    }
}
