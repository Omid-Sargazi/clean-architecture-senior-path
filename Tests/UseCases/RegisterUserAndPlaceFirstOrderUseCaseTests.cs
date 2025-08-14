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

        [Fact]
        public void Should_Fail_When_UserAlreadyExists()
        {
            var userRepo = new InMemoryUserRepository();
            var orderRepo = new InMemoryOrderRepository();
            var useCase = new RegisterUserAndPlaceFirstOrderUseCase(userRepo, orderRepo);

            var userRequest = new RegisterUserRequest
            {
                Email = "duplicate@example.com",
                Password = "pass1234"
            };

            var orderRequest = new PlaceOrderRequest
            {
                Items = new List<string> { "item" },
                TotalAmount = 50
            };

            useCase.Execute(userRequest, orderRequest);

            var result = useCase.Execute(userRequest, orderRequest);
            result.Should().Be("User already exists");
        }
        [Fact]
        public void Should_Fail_When_NoItemsForOrder()
        {
            var useRepo = new InMemoryUserRepository();
            var orderRepo = new InMemoryOrderRepository();
            var useCase = new RegisterUserAndPlaceFirstOrderUseCase(useRepo, orderRepo);

            var userRequest = new RegisterUserRequest
            {
                Email = "o@o.com",
                Password = "pass1234"
            };

            var orderRequest = new PlaceOrderRequest
            {
                Items = new List<string>(),
                TotalAmount = 0
            };

            var result = useCase.Execute(userRequest, orderRequest);

            result.Should().Be("No items for order");
        }
    }
}