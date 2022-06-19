using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariTakipProjesi
{
    class Islem3 : IIslem
    {
        public int Kimlik { get; set; }
        public int Id { get; set; }
        public string Tarih { get; set; }
        public double Fiyat { get; set; }
        public double Miktar { get; set; }
        public string MalCinsi { get; set; }
        public string Aciklama { get; set; }
        public double ToplamFiyat { get; set; }
        public string TabloIslem { get; set; }
        public Islem3()
        {
            TabloIslem = "Tablo3Islem";
        }
    }
}
