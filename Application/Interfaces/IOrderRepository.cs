using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order? GetById(Guid id);
    }
}