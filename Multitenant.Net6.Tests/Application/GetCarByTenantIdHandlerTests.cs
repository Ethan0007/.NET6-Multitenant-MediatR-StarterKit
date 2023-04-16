using Moq;
using Multitenant.Net6.Application.Commands.Car;
using Multitenant.Net6.Application.Queries.Car;
using Multitenant.Net6.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Multitenant.Net6.Tests.Application
{
    using Car = Domain.Entity.Car;

    public class GetCarByTenantIdHandlerTests
    {
        private readonly Mock<IRepository<Car>> _repository;

        public GetCarByTenantIdHandlerTests()
        {
            _repository = new Mock<IRepository<Car>>();
        }

        [Theory]
        [InlineData("Honda")]
        public async void ShouldSaveCarCommand(string tenantId)
        {
            var command = new Car("Honda Civic", 2514,
                                "Z021646TEST123JA4J3UA89P",
                                "Automatic", "Red", "Black", 
                                tenantId);

            _repository.Setup(f => f.Add(command)).Returns(Task.CompletedTask);

            var createCarCommand = new CreateCarCommand("Honda Civic",
                                2514, "Z021646TEST123JA4J3UA89P",
                                "Automatic", "Red", "Black",
                                tenantId);

            var handler = new CreateCarCommandHandler(_repository.Object);

            var result = await handler.Handle(createCarCommand, default);

            Assert.True(result);
        }
    }       
}
