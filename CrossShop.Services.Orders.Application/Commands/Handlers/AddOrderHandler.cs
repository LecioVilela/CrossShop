using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossShop.Services.Orders.Core.Repositories;
using MediatR;

namespace CrossShop.Services.Orders.Application.Commands.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrder, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(AddOrder request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}