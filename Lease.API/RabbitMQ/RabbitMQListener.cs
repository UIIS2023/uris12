﻿
using Lease.API.Controllers;
using Lease.API.Models.LeaseAgreementModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Lease.API.RabbitMQ;

public class RabbitMQListener : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly EventingBasicConsumer _consumer;
    private readonly string queueName;

    public RabbitMQListener(string hostName, string queueName, string userName, string password)
    {
        this.queueName = queueName;

        var factory = new ConnectionFactory
        {
            HostName = hostName,
            UserName = userName,
            Password = password
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        _channel.ExchangeDeclare("my_exchange", ExchangeType.Direct);
        _channel.QueueBind(queueName, "my_exchange", "lease");
        _consumer = new EventingBasicConsumer(_channel);
    }

    public async Task StartListening(Action<string> handleMessage)
    {

        _consumer.Received += async (model, ea) =>
         {
             var body = ea.Body.ToArray();
             var json = Encoding.UTF8.GetString(body);
             Console.WriteLine("Received message: {0}", json);
             var message = JsonSerializer.Deserialize<ConsumerMessageFormat>(json);


             Random random = new Random();
             string referenceNumber = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 9)
           .Select(s => s[random.Next(s.Length)]).ToArray());

             LeaseAgreementPostRequestModel leaseAgreementPostRequestModel = new LeaseAgreementPostRequestModel(referenceNumber, Enums.GuaranteeType.None, DateTime.UtcNow, Guid.Parse("b415d4f5-6342-41f3-9935-08db10fc223b"), DateTime.UtcNow.AddYears(5), "Opstina Subotica", DateTime.UtcNow, Guid.Parse(message.Guid), Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), Enums.DocumentStatus.None, Guid.Parse("b415d4f5-6342-41f3-9935-08db10fc223b"));

             var requester = new Requester();
             await requester.PostNewLeaseAgreement(leaseAgreementPostRequestModel);

             _channel.BasicAck(ea.DeliveryTag, false);
         };
        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: _consumer);
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}

