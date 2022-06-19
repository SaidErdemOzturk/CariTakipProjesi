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
    public partial class IslemOdemeForm : Form
    {
        IPerson person;
        IIslem islem;
        IDataBase dataBase;
        public IslemOdemeForm(IPerson person,IIslem islem)
        {
            InitializeComponent();
            dataBase = new SqlDatabase();
            this.person = person;
            this.islem = islem;
        }

        private void IslemOdemeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = person.Id.ToString();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem.Id = person.Id;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            islem.Tarih = dateTimePicker1.Text;
            islem.Fiyat = double.Parse(textBox2.Text);
            islem.Fiyat = islem.Fiyat * -1;
            islem.Miktar = 1;
            islem.MalCinsi = "";
            islem.Aciklama = textBox4.Text;
            islem.ToplamFiyat = islem.Fiyat;
            dataBase.IslemAdd(islem, person);
            this.Hide();
        }
    }
}
