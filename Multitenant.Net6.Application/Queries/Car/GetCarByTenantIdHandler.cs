using MediatR;
using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.Domain.Repository;
using Multitenant.Net6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Queries.Car
{
    using Car = Domain.Entity.Car;

    public class GetCarByTenantIdHandler: IRequestHandler<GetCarByTenantId , List<GetCarByTenantIdResult>>, IMediatorHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByTenantIdHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarByTenantIdResult>> Handle(GetCarByTenantId request, CancellationToken cancellationToken)
        {
            var result = _repository.Find(c => c.TenantId == request.TenantId);

            if (result is null) throw new ArgumentNullException("Car not found!");

            return await result.Select( c => new GetCarByTenantIdResult()
            {
                Id = c.Id,
                Name = c.Name,
                InteriorColor = c.InteriorColor,
                ExteriorColor = c.ExteriorColor,
                Price = c.Price,
                TenantId = c.TenantId,
                Transmission = c.Transmission,
                VIN = c.VIN
            }).ToListAsync();   
        }
    }
}
