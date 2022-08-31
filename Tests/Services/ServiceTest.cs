using Data.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Services;

namespace Tests.Services
{

    [TestClass]
    public class ServiceTest
    {
        List<Position> listPosition;
        Position pos;
        string file;
        public ServiceTest() 
        {
            file = File.ReadAllText(@$"C:\Projetos\ProjetoToro\ProjetoToro\position_1234.json");
            pos = JsonConvert.DeserializeObject<Position>(file);
            listPosition = new List<Position>() { pos };
        }


        [TestMethod]
        public async Task ConsultarPosicao()
        {
            ///Arrange
            var repository = new Mock<IUserPositionsRepository>();
            var logger = new Mock<ILoggerFactory>();


            ///Act
            repository.Setup(x => x.ListarPosicoes()).ReturnsAsync(listPosition);
            var service = new UserPositionService(logger.Object ,repository.Object);
            var retorno = await service.Get();


            ///Assert
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Any());
            repository.Verify(x => x.ListarPosicoes(), Times.Once);
        }

        [TestMethod]
        public async Task VerificaArquivoProcessado()
        {
            Assert.IsTrue(file.Any());
        }

        [TestMethod]
        public async Task SaldoMaiorZero()
        {
            Assert.IsTrue(pos.checkingAccountAmount > 0);
        }

        [TestMethod]
        public async Task PosicaoDiferentedeNull()
        {
            Assert.IsTrue(pos.positions.ToList() != null);
        }


    }
}

