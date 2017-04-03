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
                var testUser = new User()
                {
                    Name = "Admin",
                    MiddleName = "System Administrator",
                    LastName = "Sysadmin",
                    Address = "localhost",
                    Phone = "1337",
                    Email = "admin@admin.com",
                    UserName = "admin",
                    Password = "password"
                };

                var testUser2 = new User()
                {
                    Name = "Test",
                    MiddleName = "Test Middle",
                    LastName = "Test Last",
                    Address = "Address 1032, Country",
                    Phone = "10004",
                    Email = "testuser@mail.com",
                    UserName = "test",
                    Password = "password"
                };

                _context.Users.Add(testUser);
                _context.Users.Add(testUser2);
            }

            if (!_context.Providers.Any())
            {
                var testProvider = new Provider()
                {
                    Company = "Amazon",
                    Address = "Seattle",
                    Phone = "+1 206-266-2992"
                };

                var testProvider2 = new Provider()
                {
                    Company = "Lynda",
                    Address = "California",
                    Phone = "+1 888-335-9632"
                };

                _context.Providers.Add(testProvider);
                _context.Providers.Add(testProvider2);
            }

            if (!_context.Orders.Any())
            {
                var testOrder = new BookOrder()
                {
                    Author = "Edgar Allan Poe",
                    Name = "The Cask Of Amontillado",
                    ISBN = "9781515185222",
                    Requestor = new User()
                    {
                        Name = "ExampleUser"
                    },
                    Provider = new Provider()
                    {
                        Company = "Audible"
                    },
                    Ordered = DateTime.Today,
                    Price = 400.00,
                };

                _context.Orders.Add(testOrder);
            }
            await _context.SaveChangesAsync();
        }
    }
}
