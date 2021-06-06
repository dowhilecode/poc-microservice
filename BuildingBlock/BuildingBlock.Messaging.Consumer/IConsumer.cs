using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlock.Messaging.Consumer
{
    public interface IConsumer
    {
        public string QueueName { get; set; }
        public string HostName { get; set; }
        bool Consume(out string queueMessage);
    }
}
