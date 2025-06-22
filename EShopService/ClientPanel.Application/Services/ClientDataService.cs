using ClientPanel.Domain.Repositories;
using ClientPanel.Domain.Models;

namespace ClientDataBase.Application.Services;

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
