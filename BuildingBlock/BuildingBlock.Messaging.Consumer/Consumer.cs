using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlock.Messaging.Consumer
{
    public class Consumer : IConsumer
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        private IConnection connection;
        private string message;

        private bool Validatoin()
        {
            if (string.IsNullOrEmpty(HostName))
                return false;

            return true;
        }

        private bool Connect()
        {
            if (!Validatoin())
                return false;


            var Factory = new ConnectionFactory() { HostName = HostName };
            connection = Factory.CreateConnection();

            return true;
        }

        public bool Consume(out string queueMessage)
        {
            queueMessage = string.Empty;
            if (!Connect())
                return false;

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                queueMessage = message;
                channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);
            }

            return true;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            message = Encoding.UTF8.GetString(body);
        }
    }
}
