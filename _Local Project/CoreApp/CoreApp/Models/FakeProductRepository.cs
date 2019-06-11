using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product(){Id=1, Name="IPhone", Price=2000, Category="Mobile"},
            new Product(){Id=1, Name="Samsung", Price=3000, Category="Mobile"},
            new Product(){Id=1, Name="Hp", Price=1000, Category="Mobile"}

        }.AsQueryable();
    }
}
