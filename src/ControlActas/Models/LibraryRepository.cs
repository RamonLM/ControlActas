using Microsoft.EntityFrameworkCore;
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

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            _logger.LogInformation("Getting users from database...");
            return _context.Users.ToList();
        }

        public IEnumerable<BookOrder> GetAllOrders()
        {
            _logger.LogInformation("Getting orders from database...");
            return _context.Orders
                .Include(o => o.Requestor)
                .Include(o => o.Provider)
                .ToList();
        }

        public IEnumerable<BookOrder> GetOrdersByRequestor(User user)
        {
            return _context.Orders
                .Include(o => o.Requestor)
                .Include(o => o.Provider)
                .Where(o => o.Requestor == user)
                .ToList();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users
                .Where(u => u.UserName == username)
                .FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public BookOrder GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Requestor)
                .Include(o => o.Provider)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public void AddOrder(string username, BookOrder newOrder)
        {
            var user = GetUserByUsername(username);

            if(user != null)
            {
                newOrder.Requestor = user;
                _context.Add(newOrder);
            }
        }
    }
}
