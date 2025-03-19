using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Domain.Request;
using Domain.Response;
using Domain.Services;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly PaymentProcessor _paymentProcessor;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<IOrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(PaymentProcessor paymentProcessor, IOrderRepository orderRepository, ILogger<IOrderService> logger, ICustomerRepository customerRepository, IMapper mapper)
        {
            _paymentProcessor = paymentProcessor;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DefaultApiResponse<OrderResponse>> PayOrderAsync(PaymentRequest request)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

                if (customer == null)
                {
                    throw new ArgumentException($"Customer not found with id {request.CustomerId}");
                }

                if (request.PaymentValue <= 0)
                {
                    throw new ArgumentException("Order value must be greater than zero.");
                }

                var order = new Order(request.PaymentValue, customer);

                await InsertOrderAsync(order);

                await _paymentProcessor.ProcessPayment(request.PaymentMethod, request.PaymentValue);

                await _orderRepository.SaveChangesAsync();

                var response = _mapper.Map<OrderResponse>(order);
                return new DefaultApiResponse<OrderResponse>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error");
                throw; 
            }
        }


        private async Task InsertOrderAsync(Order order)
            => await _orderRepository.AddAsync(order);
    }
}