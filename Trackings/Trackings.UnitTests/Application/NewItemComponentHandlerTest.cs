using Trackings.Application.Commands;
using Trackings.Domain.Aggregates;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Trackings.UnitTests.Application
{
    public class NewItemComponentHandlerTest
    {
        private readonly Mock<IItemComponentRepository> _itemComponentRepositoryMock;
        public NewItemComponentHandlerTest()
        {
            _itemComponentRepositoryMock = new Mock<IItemComponentRepository>();
        }

        [Fact]
        public async Task handle_itemComponent_is_persisted()
        {
            var fakeItemComponent = GetFakeCreateItemComponentCommand();

            _itemComponentRepositoryMock.Setup(validation => validation.ValidateItemComponentName(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(false);
            _itemComponentRepositoryMock.Setup(areaRepo => areaRepo.Register(It.IsAny<ItemComponent>()))
                .ReturnsAsync(1);

            var handler = new CreateItemComponentCommandHandler(_itemComponentRepositoryMock.Object);
            var cltToken = new CancellationToken();
            var result = await handler.Handle(fakeItemComponent, cltToken);

            Assert.True(true);
        }

        private CreateItemComponentCommand GetFakeCreateItemComponentCommand()
        {
            return new CreateItemComponentCommand() { name = "Comercial", typeLocalId = 71294, wattsXm2 = 23, kiloWatts = 5, predecessor = 9, saleReport = true };
        }
    }
}
