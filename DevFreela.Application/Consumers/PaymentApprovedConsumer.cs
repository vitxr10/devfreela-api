using DevFreela.Application.DTOs;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Application.Consumers
{
    public class PaymentApprovedConsumer : BackgroundService
    {
        private readonly string APPROVED_PAYMENTS_QUEUE = "ApprovedPayments";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ConnectionFactory _factory;
        private readonly IServiceProvider _serviceProvider;
        public PaymentApprovedConsumer(ConnectionFactory factory, IServiceProvider serviceProvider)
        {
            _factory = factory;
            _serviceProvider = serviceProvider;
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: APPROVED_PAYMENTS_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);
                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

                await FinishProject(paymentApprovedIntegrationEvent.ProjectId);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(APPROVED_PAYMENTS_QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        public async Task FinishProject(int id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepository.GetByIdAsync(id);

                project.Finish();

                await projectRepository.SaveAsync();
            }
        }
    }
}
