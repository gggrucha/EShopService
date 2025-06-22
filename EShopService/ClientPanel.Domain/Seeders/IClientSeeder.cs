using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataBase.Domain.Seeders
{
    public interface IClientSeeder
    {
        Task Seed();
    }
}
