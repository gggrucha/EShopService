﻿using ClientDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataBase.Domain.Repositories;

public interface IRepository
{
    Task<Client> AddClientAsync(Client client);
    Task<Client> GetClientAsync(int id);
    Task<List<Client>> GetAllClientsAsync();
    Task<bool> DeleteClientAsync(int id);
}
