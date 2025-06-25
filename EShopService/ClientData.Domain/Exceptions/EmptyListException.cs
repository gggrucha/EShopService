using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientData.Domain.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException() : base("List of clients is empty"){ }
    }
}
