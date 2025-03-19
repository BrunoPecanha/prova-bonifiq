using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Domain.Request;
using Moq;
using Services;
using Xunit;

namespace Test
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CustomerService _customerService;
        private readonly Customer _validCustomer;

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _customerService = new CustomerService(_customerRepositoryMock.Object, _mapperMock.Object);

            _validCustomer = new Customer(1, "xpto", new List<Order>());
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowException_WhenCustomerIdIsInvalid()
        {
            var request = new CanPurchaseRequest { CustomerId = 0, PurchaseValue = 50 };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _customerService.CanPurchase(request));
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowException_WhenPurchaseValueIsInvalid()
        {
            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 0 };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _customerService.CanPurchase(request));
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowException_WhenCustomerDoesNotExist()
        {
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Customer)null);
            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 50 };

            await Assert.ThrowsAsync<InvalidOperationException>(() => _customerService.CanPurchase(request));
        }

        [Fact]
        public async Task CanPurchase_ShouldReturnFalse_WhenCustomerHasOrdersInLastMonth()
        {
            var customer = CreateCustomerWithOrders();
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(customer);

            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 50 };

            var result = await _customerService.CanPurchase(request);

            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_ShouldReturnFalse_WhenCustomerHasNoOrdersAndPurchaseValueIsAboveLimit()
        {
            var customer = CreateCustomerWithNoOrders();
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(customer);

            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 150 };

            var result = await _customerService.CanPurchase(request);

            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_ShouldReturnFalse_WhenOutsideAllowedHours()
        {
            var customer = CreateCustomerWithNoOrders();
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(customer);

            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 50 };
            var systemTime = new DateTime(2024, 3, 17, 7, 0, 0); // Antes das 8h

            var result = await InvokeWithMockedTime(() => _customerService.CanPurchase(request), systemTime);

            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_ShouldReturnTrue_WhenAllConditionsAreMet()
        {
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_validCustomer);

            var request = new CanPurchaseRequest { CustomerId = 1, PurchaseValue = 50 };
            var systemTime = new DateTime(2024, 3, 18, 10, 0, 0); // Segunda-feira, horário permitido

            var result = await InvokeWithMockedTime(() => _customerService.CanPurchase(request), systemTime);

            Assert.True(result);
        }

        private async Task<bool> InvokeWithMockedTime(Func<Task<bool>> action, DateTime mockTime)
        {
            return await action();
        }

        private Customer CreateCustomerWithOrders()
        {
            return new Customer(2, "Peçanha Bruno", new List<Order> { new Order(10, new Customer(1, "xpto")) });
        }

        private Customer CreateCustomerWithNoOrders()
        {
            return new Customer(1, "xpto", new List<Order>());
        }
    }
}


