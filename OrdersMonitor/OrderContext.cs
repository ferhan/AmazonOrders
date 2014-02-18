using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrdersMonitor
{
    class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
