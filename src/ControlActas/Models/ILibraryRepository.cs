using System.Collections.Generic;

namespace ControlActas.Models
{
    public interface ILibraryRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}