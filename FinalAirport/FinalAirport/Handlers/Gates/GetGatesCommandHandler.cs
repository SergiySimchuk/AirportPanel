using FinalAirport.Commands.Gates;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Gates
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
