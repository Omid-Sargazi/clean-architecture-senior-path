using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class PlaceOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public PlaceOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public PlaceOrderResponse Execute(PlaceOrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
            {
                return new PlaceOrderResponse { Success = false, Message = "No items in order." };
            }

            var order = new Order(request.Items, request.TotalAmount);
            _orderRepository.Save(order);

            return new PlaceOrderResponse { Success = true, Message = "Order placed successfully." };
        }
    }
}