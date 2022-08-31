using Domain.Entities;

namespace Services.Interfaces
{
    public interface IUserPositionService
    {
        Task<IEnumerable<Position>> Get();
        Task ProcessarPosicao();
    }
}