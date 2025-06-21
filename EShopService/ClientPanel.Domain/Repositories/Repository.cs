using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientPanel.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientPanel.Domain.Repositories;

public class Repository 
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
    public async Task<Client> DeleteClientAsync(Client client)
    {
        _context.Remove(client);
        await _context.SaveChangesAsync();
        return client;
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

