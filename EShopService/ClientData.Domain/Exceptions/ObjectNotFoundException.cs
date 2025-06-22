using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientData.Domain.Exceptions;

public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException() : base("Client was not found in this database.") { }

}
