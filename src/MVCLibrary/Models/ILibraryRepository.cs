using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlActas.Models
{
    public interface ILibraryRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<BookOrder> GetAllOrders();
        void AddUser(User user);
        User GetUserByUsername(string username);
        Task<bool> SaveChangesAsync();
        IEnumerable<BookOrder> GetOrdersByRequestor(User user);
        BookOrder GetOrderById(int id);
        void AddOrder(string username, BookOrder newOrder);
    }
}