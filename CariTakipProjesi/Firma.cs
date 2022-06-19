using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariTakipProjesi
{
    class Firma : IPerson
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string OzelKod { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public double Bakiye { get; set; }
        public string Tablo { get; set; }
        public Firma()
        {
            Tablo = "Tablo2";
        }
    }
}
