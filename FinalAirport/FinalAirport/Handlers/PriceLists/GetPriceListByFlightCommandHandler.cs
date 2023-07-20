using AutoMapper;
using FinalAirport.Commands.PriceLists;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.PriceLists
{
    public class GetPriceListByFlightCommandHandler : IRequestHandler<GetPriceListsByFlightCommand, ICollection<PriceList>>
    {
        private readonly IPriceListRepository repository;
        private readonly IMapper mapper;

        public GetPriceListByFlightCommandHandler(IPriceListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<PriceList>> Handle(GetPriceListsByFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = this.mapper.Map<Flight>(request);

            return await repository.GetPriceListsByFlight(flight);
        }
    }
}
