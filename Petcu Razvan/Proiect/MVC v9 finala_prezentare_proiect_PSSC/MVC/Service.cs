using ClassLibrary1;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE
{
    public interface IService
    {
        void Add_client(Model_clienti m);
    }
    public class Service:IService
    {
        private readonly IBusControl bus;
        public Service(IBusControl bus)
        {
            this.bus = bus;
        }
        public void Add_client(Model_clienti m)
        {
            bus.Publish(new Model_clienti()
            {
               carte_de_credit=m.carte_de_credit,
               CCV=m.CCV,
               check_in=m.check_in,
               check_out=m.check_out,
               Data_expirarii=m.Data_expirarii,
               email=m.email,
               fail=m.fail,
               ID=m.ID,
               id_camera=m.id_camera,
               Mentiuni=m.Mentiuni,
               numar_carte=m.numar_carte,
               Nume=m.Nume,
               Prenume=m.Prenume,
               stare=m.stare,
               tip_camera=m.tip_camera
            });
        }
    }
}
