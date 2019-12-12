using MassTransit;
using MVC_CORE.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CORE
{
    public interface ISender_coada
    {
        void Send(Model_clienti c);
    }
    public class Sender_coada:ISender_coada
    {
        private IBusControl bus;

        public Sender_coada(IBusControl bus)
        {
            this.bus = bus;
        }
        public void Send(Model_clienti c)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("amqp://xjkfljkg:6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs@hawk.rmq.cloudamqp.com/xjkfljkg"), h =>
                {
                    h.Username("xjkfljkg");
                    h.Password("6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs");
                });
            });

            bus.Start();
            this.bus = bus;
            bus.Publish(new Model_clienti()
            {
                ID = c.ID,
                Nume = c.Nume,
                Prenume = c.Prenume,
                tip_camera = c.tip_camera,
                check_in = c.check_in,
                check_out = c.check_out,
                carte_de_credit = c.carte_de_credit,
                numar_carte = c.numar_carte,
                Data_expirarii = c.Data_expirarii,
                CCV = c.CCV,
                Mentiuni = c.Mentiuni,
                id_camera = c.id_camera,
                stare = c.stare,
                fail = c.fail,
                email = c.email
            });
        }
        public Sender_coada() { }
    }
}
