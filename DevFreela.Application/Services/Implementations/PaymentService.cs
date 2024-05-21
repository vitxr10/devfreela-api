using DevFreela.Application.DTOs;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";
        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfo)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfo);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}
