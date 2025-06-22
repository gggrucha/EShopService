using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientData.Domain.Repositories;
using ClientData.Domain.Models;
namespace ClientData.Application.Services;

public class ClientDataService : IClientDataService
{
    private readonly IRepository _repository;
    public ClientDataService(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<Client> AddClientAsync(Client client)
    {
        return await _repository.AddClientAsync(client);
    }
    public async Task<bool> DeleteClientAsync(int id)
    {
        return await _repository.DeleteClientAsync(id);
    }
    public async Task<Client> GetClientAsync(int id)
    {
        return await _repository.GetClientAsync(id);
    }
    public async Task<List<Client>> GetAllClientsAsync()
    {
        return await _repository.GetAllClientsAsync();
    }
}

