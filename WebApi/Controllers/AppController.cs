using Application.DTOs;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AppController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        public AppController(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserRequest request)
        {
            var useCase = new RegisterUserUseCase(_userRepository);
            var result = useCase.Execute(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("placeorder")]
        public IActionResult PlaceOrder(PlaceOrderRequest request)
        {
            var useCase = new PlaceOrderUseCase(_orderRepository);
            var result = useCase.Execute(request);
            return result.Success ? Ok(result) : BadRequest(request);
        }
         
    }
}