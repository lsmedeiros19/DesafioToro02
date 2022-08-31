using Domain.Entities;

namespace Data.Interfaces
{
    public interface IUserPositionsRepository
    {
        Task<IEnumerable<Position>> ListarPosicoes();
        Task<List<Equity>> ListarAcoes();
        Task Incluir(Position obj);
    }
}