using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Domain.Models;

namespace ClientData.Domain.Repositories;
public class Repository : IRepository
{
    public readonly DataContext _context;
    public Repository(DataContext context)
    {
        _context = context;
    }
    //dodaj użytkownika
    public async Task<Client> AddClientAsync(Client client)
    {
        _context.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }
    //usuń użytkownika
    public async Task<bool> DeleteClientAsync(int id)
    {

        var client = await _context.Clients.FindAsync(id);
        if (client == null) return false; //FindAsync returns ValueTask<Client> not a Client
        _context.Remove(client);
        await _context.SaveChangesAsync();
        return true;

    }

    //get użytkownika
    public async Task<Client> GetClientAsync(int id)
    {
        return await _context.Clients.Where(s => s.Id == id).FirstOrDefaultAsync();
    }

    //get wszystkich użytkoników
    public async Task<List<Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }
}
