using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlock.Messaging.Publisher
{
    public interface IPublisher
    {
        public string QueueName { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        string TestConnection();
        bool Send(string message);
    }
}
