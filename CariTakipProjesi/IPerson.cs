using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;

namespace CariTakipProjesi
{
    public interface IPerson
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string OzelKod { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public double Bakiye { get; set; }

        public string Tablo { get; set; }

    }

    public abstract class IPerson2
    {

    }
}
