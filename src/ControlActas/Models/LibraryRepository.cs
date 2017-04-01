using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Models
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryContext _context;
        private ILogger<ILibraryRepository> _logger;

        public LibraryRepository(LibraryContext context, ILogger<ILibraryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<User> GetAllUsers()
        {
            _logger.LogInformation("Getting users from database...");
            return _context.Users.ToList();
        }
    }
}
