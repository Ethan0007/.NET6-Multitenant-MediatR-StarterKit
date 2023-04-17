using MediatR;
using Multitenant.Net6.Application.Interface;
using Multitenant.Net6.Domain.Repository;
 
namespace Multitenant.Net6.Application.Commands.Car
{
    using Car = Domain.Entity.Car;

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>, IMediatorHandler
    {
        private readonly IRepository<Car> _repository;
         
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            await _repository.Add(new Car(command.Name, 
                command.Price.GetValueOrDefault(),
                command.VIN, command.Transmission, command.ExteriorColor, 
                command.InteriorColor, command.TenantId));

            return true;
        }
    }
}
