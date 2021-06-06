using System;
using BuildingBlock.Messaging.Publisher;
namespace MessagingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPublisher pub = new Publisher();
            pub.HostName = "localhost";
            pub.UserName = "guest";
            pub.Password = "guest";
            pub.QueueName = "test";
            pub.Send("hello from publisher");
            Console.WriteLine("Hello World!");
        }
    }
}
