using Data.Interfaces;
using Data.Repository;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Services
{
    public class UserPositionService : IUserPositionService
    {
        private ILogger<UserPositionService> Logger;
        private IUserPositionsRepository Repository { get; }

        public UserPositionService(ILoggerFactory logger, IUserPositionsRepository repository)
        {
            Logger = logger.CreateLogger<UserPositionService>();
            Repository = repository;
        }

        public async Task<IEnumerable<Position>> Get()
        {
            var ret = await Repository.ListarPosicoes();
            ret.ToList().ForEach(async x => {
                var acoes = await Repository.ListarAcoes();
                x.positions = acoes;
                x.consolidated = (acoes?.Select(x => x.amount * x.currentPrice).Sum()).GetValueOrDefault(0) + x.checkingAccountAmount;
            });
            return ret;
        }

        public async Task ProcessarPosicao()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var file = File.ReadAllText(@$"{currentDirectory}\position_1234.json");
                var pos = JsonConvert.DeserializeObject<Position>(file);

                await Incluir(pos);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível processar o arquivo position_1234.json", ex);
            }
        }

        public async Task Incluir(Position obj) 
        {
            try
            {
                await Repository.Incluir(obj);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Não foi possível a inclusão das posições do cliente. {obj.cblc}", ex);
            }
        } 
    }

}
