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
    public partial class IslemEkleForm : Form
    {
        IDataBase dataBase;
        IIslem islem;
        IPerson person;
        public IslemEkleForm(IPerson person,IIslem islem)
        {
            InitializeComponent();
            dataBase = new SqlDatabase();
            this.person = person;
            this.islem = islem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            islem.Id = person.Id;
            islem.Tarih = dateTimePicker1.Text;
            islem.Fiyat = double.Parse(textBox2.Text);
            islem.Miktar = double.Parse(textBox3.Text);
            islem.MalCinsi = textBox4.Text;
            islem.Aciklama = textBox5.Text;
            islem.ToplamFiyat = islem.Fiyat * islem.Miktar;
            dataBase.IslemAdd(islem, person);
        }

        private void IslemEkleForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = person.Id.ToString(); ;
        }
    }
}
