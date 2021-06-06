using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlock.Messaging.Publisher
{
    public class Publisher : IPublisher
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private IConnection connection;
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


            var Factory = new ConnectionFactory() 
            { 
                HostName = HostName, 
                Password = Password, 
                UserName = UserName 
            };
            connection = Factory.CreateConnection();
            return true;
        }

        public bool Send(string message)
        {
            if (!Connect())
                return false;

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            }

            return true;
        }

        public string TestConnection()
        {
            return "OK";
        }
    }

}
