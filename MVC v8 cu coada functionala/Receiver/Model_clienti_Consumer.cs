using ClassLibrary1;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    class Model_clienti_Consumer : IConsumer<Model_clienti>
    {
        public static Model_clienti m = new Model_clienti();
        public async Task Consume(ConsumeContext<Model_clienti> context)
        {
            memory(context);
            await Console.Out.WriteLineAsync("OK");
        }
        private void memory(ConsumeContext<Model_clienti> context)
        {
            m.Nume = context.Message.Nume;
            m.Prenume = context.Message.Prenume;
            m.check_in = context.Message.check_in;
            m.check_out = context.Message.check_out;
            m.carte_de_credit = (ClassLibrary1.Model_clienti.Carte_de_credit)context.Message.carte_de_credit;
            m.Data_expirarii = context.Message.Data_expirarii;
            m.CCV = context.Message.CCV;
            m.tip_camera = (ClassLibrary1.Model_clienti.Tip_camera)context.Message.tip_camera;
            m.Mentiuni = context.Message.Mentiuni;
            m.ID = context.Message.ID;
            m.id_camera = context.Message.id_camera;
            m.stare = (ClassLibrary1.Model_clienti.Stare)context.Message.stare;
            m.fail = context.Message.fail;
            m.email = context.Message.email;
        }
    }
}
