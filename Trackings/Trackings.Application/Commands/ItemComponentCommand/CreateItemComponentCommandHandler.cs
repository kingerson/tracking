using Trackings.Domain.Aggregates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Trackings.Application.Commands
{
    public class CreateItemComponentCommandHandler : IRequestHandler<CreateItemComponentCommand, int>
    {
        readonly IItemComponentRepository _iItemComponentRepository;

        public CreateItemComponentCommandHandler(IItemComponentRepository iItemComponentRepository)
        {
            _iItemComponentRepository = iItemComponentRepository;
        }

        public async Task<int> Handle(CreateItemComponentCommand request, CancellationToken cancellationToken)
        {
            ItemComponent itemComponent = new ItemComponent(request.name, request.typeLocalId, request.wattsXm2, request.kiloWatts, request.predecessor, request.saleReport);

            var result = await _iItemComponentRepository.Register(itemComponent);

            return result;
        }
    }
}
