using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientDataBase.Domain.Models;
namespace ClientDataBase.Application.Services;

public interface IClientDataService
{
    Task<Client> AddClientAsync(Client client);
    Task<Client> GetClientAsync(int id);
    Task<List<Client>> GetAllClientsAsync();
    Task<bool> DeleteClientAsync(int id);
}
