using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossShop.Services.Orders.Core.Entities;

namespace CrossShop.Services.Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}