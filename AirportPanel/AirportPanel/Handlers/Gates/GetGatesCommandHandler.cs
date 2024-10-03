using AirportPanel.Commands.Gates;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Gates
{
    public class GetGatesCommandHandler : IRequestHandler<GetGatesCommand, ICollection<Gate>>
    {
        private readonly IGatesRepository gatesRepository;

        public GetGatesCommandHandler(IGatesRepository gatesRepository)
        {
            this.gatesRepository = gatesRepository;
        }

        public async Task<ICollection<Gate>> Handle(GetGatesCommand request, CancellationToken cancellationToken)
        {
            return await gatesRepository.GetAll();
        }
    }
}
