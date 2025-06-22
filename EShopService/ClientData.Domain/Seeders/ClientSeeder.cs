using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Domain.Repositories;
using ClientData.Domain.Models;

namespace ClientData.Domain.Seeders;
public class ClientSeeder(DataContext context) : IClientSeeder
{
    public async Task Seed()
    {
        //weykona się jeśli baza danych będzie pusta
        if (!context.Clients.Any())
        {
            var manyClients = new List<Client>
            {
                new Client
                {
                    Id = 21,
                    Username = "Miou Lioung",
                    Email = "client21@email.com",
                    PasswordHash = "strongP129332rd",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    LastLoginAt = DateTime.UtcNow.AddMinutes(-10),
                    IsActive = false
                },
                new Client
                {
                    Id = 22,
                    Username = "Friedrich Schulz",
                    Email = "client22@email.com",
                    PasswordHash = "strongP129332rd",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    LastLoginAt = DateTime.UtcNow.AddMinutes(-10),
                    IsActive = false
                },
                new Client
                {
                    Id = 23,
                    Username = "Richard Bereck",
                    Email = "client23email.com",
                    PasswordHash = "strongP129332rd",
                    CreatedAt = DateTime.UtcNow.AddDays(-23),
                    LastLoginAt = DateTime.UtcNow,
                    IsActive = true
                }
            };
            context.Clients.AddRange(manyClients);
            context.SaveChanges();
        }
    }
}
