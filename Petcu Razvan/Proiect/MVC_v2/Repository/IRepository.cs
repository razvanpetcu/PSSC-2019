using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    interface IRepository
    {
        void Adaugare_rezervare();
        void Delete_rezervare();
        IRepository citire_date();
    }
}
