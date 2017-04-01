using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Models
{
    public class LibraryContextSeedData
    {
        private LibraryContext _context;

        public LibraryContextSeedData(LibraryContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Users.Any())
            {
                var usuarioAdmin = new User()
                {
                    Name = "Admin",
                    UserName = "admin",
                    Password = "password"
                };

                _context.Users.Add(usuarioAdmin);

                var usuarioTest = new User()
                {
                    Name = "Test",
                    UserName = "test",
                    Password = "password"
                };

                _context.Users.Add(usuarioTest);
            }
            await _context.SaveChangesAsync();
        }
    }
}
