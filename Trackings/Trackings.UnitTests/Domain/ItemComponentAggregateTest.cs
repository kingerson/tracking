using Trackings.Domain.Aggregates;
using Xunit;

namespace Trackings.UnitTests.Domain
{
    public class ItemComponentAggregateTest
    {
        public ItemComponentAggregateTest() { }

        [Fact]
        public void create_itemComponent_success()
        {
            string name = "Comercial";
            int typeLocalId = 71294;
            int wattsXm2 = 4;
            int kiloWatts = 5;
            int predecessor = 9;
            bool saleReport = true;

            var fakeItemComponent = new ItemComponent(name, typeLocalId, wattsXm2, kiloWatts, predecessor, saleReport);

            Assert.NotNull(fakeItemComponent);
        }
    }
}
