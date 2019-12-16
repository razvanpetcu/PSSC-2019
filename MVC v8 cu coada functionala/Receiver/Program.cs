using ClassLibrary1;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
        public static Model_clienti Receiver()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host(new Uri("amqp://xjkfljkg:6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs@hawk.rmq.cloudamqp.com/xjkfljkg"), h =>
                {
                    h.Username("xjkfljkg");
                    h.Password("6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs");
                });

                sbc.ReceiveEndpoint(e =>
                {
                    e.Consumer<Model_clienti_Consumer>();
                });
            });

            bus.Start();
            return Model_clienti_Consumer.m;
        }
    }
}
