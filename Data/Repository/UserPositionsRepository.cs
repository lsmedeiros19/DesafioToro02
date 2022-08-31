using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserPositionsRepository : IUserPositionsRepository
    {
        private readonly DatabaseContext _context;
        public UserPositionsRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public async Task<IEnumerable<Position>> ListarPosicoes()
        {
            return await _context.Position.ToListAsync();
        }

        public async Task<List<Equity>> ListarAcoes()
        {
            return await _context.Equities.ToListAsync();
        }

        public async Task Incluir(Position obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
