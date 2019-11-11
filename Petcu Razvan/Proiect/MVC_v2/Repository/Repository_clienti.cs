using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Repository
{
    public class Repository_clienti
    {
        private static Baza_de_dateEntities1 _db = new Baza_de_dateEntities1();
        public static List<Tabel_clienti> lista_clienti = new List<Tabel_clienti>();

        public static void Getall()
        {
            lista_clienti = _db.Tabel_clienti.ToList();
        }
        /*
        private Guid ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public Tip_camera tip_Camera { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public Carte_de_credit carte_De_Credit { get; set; }
        public string numar_carte { get; set; }
        public string CCV { get; set; }
        public string Mentiuni { get; set; }

        public Repository_clienti() { }
        public Repository_clienti(
            string nume,
            string prenume,
            Tip_camera tip_Camera,
            DateTime check_in,
            DateTime check_out,
            string numar_carte,
            string cCV,
            string mentiuni)
        {
            ID = Guid.NewGuid();
            Nume = nume;
            Prenume = prenume;
            this.tip_Camera = tip_Camera;
            this.check_in = check_in;
            this.check_out = check_out;
            this.numar_carte = numar_carte;
            CCV = cCV;
            Mentiuni = mentiuni;
        }
        public enum Tip_camera
        {
            Lux,
            Superior,
            Standard
        }
        public enum Carte_de_credit
        {
            Master_Card,
            Visa
        }
        */
    }
}