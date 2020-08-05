using Trackings.Domain.Aggregates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Trackings.Application.Commands
{
    public class UpdateItemComponentCommandHandler : IRequestHandler<UpdateItemComponentCommand, int>
    {
        readonly IItemComponentRepository _iItemComponentRepository;

        public UpdateItemComponentCommandHandler(IItemComponentRepository iItemComponentRepository)
        {
            _iItemComponentRepository = iItemComponentRepository;
        }

        public async Task<int> Handle(UpdateItemComponentCommand request, CancellationToken cancellationToken)
        {
            ItemComponent itemComponent = new ItemComponent(request.itemComponentId, request.name, request.typeLocalId, request.wattsXm2, request.kiloWatts, request.predecessor, request.saleReport);

            var result = await _iItemComponentRepository.Register(itemComponent);

            return result;
        }
    }
}
