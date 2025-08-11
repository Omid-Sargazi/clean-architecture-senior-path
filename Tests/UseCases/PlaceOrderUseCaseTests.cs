using Application.DTOs;
using Application.UseCases;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Tests.UseCases
{
    public class PlaceOrderUseCaseTests
    {
        [Fact]
        public void Should_PlaceOrder_Successfully()
        {
            var repo = new InMemoryOrderRepository();
            var useCase = new PlaceOrderUseCase(repo);
            var request = new PlaceOrderRequest
            {
                Items = new List<string> { "item1", "item2" },
                TotalAmount = 100,
            };

            var result = useCase.Execute(request);

            result.Success.Should().BeTrue();
            result.Message.Should().Be("Order placed successfully.");
        }

        [Fact]
        public void Should_Fail_When_No_Items_Provided()
        {
            var repo = new InMemoryOrderRepository();
            var useCase = new PlaceOrderUseCase(repo);
            var request = new PlaceOrderRequest
            {
                Items = new List<string>(),
                TotalAmount = 50,
            };

            var result = useCase.Execute(request);

            result.Success.Should().BeFalse();
            result.Message.Should().Be("No items in order.");
        }
    }
}