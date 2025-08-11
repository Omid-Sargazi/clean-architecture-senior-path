using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class RegisterUserAndPlaceFirstOrderUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        public RegisterUserAndPlaceFirstOrderUseCase(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public string Execute(RegisterUserRequest userRequest, PlaceOrderRequest orderRequest)
        {
            if (_userRepository.EmailExists(userRequest.Email))
                return "User already exists";

            var user = new User(userRequest.Email, userRequest.Password);
            if (!user.IsValid())
                return "Invalid user data";

            _userRepository.Save(user);

            if (orderRequest.Items == null || !orderRequest.Items.Any())
                return "No items for order";

            var order = new Order(orderRequest.Items, orderRequest.TotalAmount);
            _orderRepository.Save(order);
            return "User registered and first order placed";
        }
    }
}