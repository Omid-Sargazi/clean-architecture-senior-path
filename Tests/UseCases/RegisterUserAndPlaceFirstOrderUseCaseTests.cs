using Application.DTOs;
using Application.UseCases;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Tests.UseCases
{
    public class RegisterUserAndPlaceFirstOrderUseCaseTests
    {
        [Fact]
        public void Should_RegisterUser_And_PlaceFirstOrder_Successfully()
        {
            var userRepo = new InMemoryUserRepository();
            var oderRepo = new InMemoryOrderRepository();
            var useCase = new RegisterUserAndPlaceFirstOrderUseCase(userRepo, oderRepo);

            var userRequest = new RegisterUserRequest
            {
                Email = "test@example.com",
                Password = "pass1234",
            };

            var orderRequest = new PlaceOrderRequest
            {
                Items = new List<string> { "item1", "item2" },
                TotalAmount = 50
            };

            var result = useCase.Execute(userRequest, orderRequest);
            result.Should().Be("User registered and first order placed");
        }
    }
}