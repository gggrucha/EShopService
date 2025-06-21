using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;


namespace ClientPanel.Domain.Models
{
    class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
       

    }
}
