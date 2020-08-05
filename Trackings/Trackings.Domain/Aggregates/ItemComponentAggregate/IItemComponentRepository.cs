using System.Threading.Tasks;

namespace Trackings.Domain.Aggregates
{
    public interface IItemComponentRepository
    {
        Task<int> Register(ItemComponent itemComponent);
        Task<bool> ValidateItemComponentName(int itemComponent_id, string name);
    }
}
