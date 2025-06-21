using ClientPanel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPanel.Domain.Repositories;

public interface IRepository
{
    Task<Client> AddClientAsync(Client client);
}
