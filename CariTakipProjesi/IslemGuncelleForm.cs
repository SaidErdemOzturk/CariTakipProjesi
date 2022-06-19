using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariTakipProjesi
{
    public partial class IslemGuncelleForm : Form
    {
        IPerson person;
        IIslem islem;
        IDataBase dataBase;
        public IslemGuncelleForm(IPerson person,IIslem islem)
        {
            InitializeComponent();
            dataBase = new SqlDatabase();
            this.person = person;
            this.islem = islem;
        }

        private void IslemGuncelleForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox6.Enabled = false;

            textBox1.Text = islem.Id.ToString();
            textBox2.Text = islem.Fiyat.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Text = islem.Tarih;
            if (islem.MalCinsi=="")
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                textBox3.Text = islem.Miktar.ToString();
                textBox4.Text = islem.MalCinsi;
                
            }
            textBox5.Text = islem.Aciklama;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.Bakiye = person.Bakiye - islem.ToplamFiyat;
            islem.Tarih = dateTimePicker1.Text;
            islem.Fiyat = double.Parse(textBox2.Text);
            islem.Miktar = double.Parse(textBox3.Text);
            islem.MalCinsi = textBox4.Text;
            islem.Aciklama = textBox5.Text;
            islem.ToplamFiyat = islem.Fiyat * islem.Miktar;
            person.Bakiye = person.Bakiye + islem.ToplamFiyat;
            dataBase.IslemUpdate(islem, person);
            this.Hide();
        }
        double sayi1 = 0;
        double sayi2 = 0;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox3.Text != "")
                {
                    sayi1 = double.Parse(textBox2.Text);

                    sayi2 = double.Parse(textBox3.Text);
                }
            }
            textBox6.Text = (sayi1 * sayi2).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
                if (textBox3.Text!="")
                {
                    sayi1 = double.Parse(textBox2.Text);

                    sayi2 = double.Parse(textBox3.Text);
                }
            }
            textBox6.Text = (sayi1 * sayi2).ToString();
        }
    }
}
