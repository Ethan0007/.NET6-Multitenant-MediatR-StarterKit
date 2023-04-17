using MediatR;
using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Application.Interface;
using Multitenant.Net6.Domain.Repository;

namespace Multitenant.Net6.Application.Commands.Car
{
    using Car = Domain.Entity.Car;

    public class UpdateCarCommandHandler: IRequestHandler<UpdateCarCommand, bool>, IMediatorHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(c => c.Id == command.Id).FirstOrDefaultAsync();

            if (result is null) return false;

            result.SetValue(command.Name, command.Price.GetValueOrDefault(),
                command.VIN, command.Transmission, command.ExteriorColor,
                command.InteriorColor);

            await _repository.Update(result);

            return true;
        }
    }
}
