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
    public partial class FormGuncelle : Form
    {
        IPerson person;
        IDataBase dataBase;

        public FormGuncelle(IPerson person)
        {
            InitializeComponent();
            dataBase = new SqlDatabase();
            this.person = person;
        }

        private void FormGuncelle_Load(object sender, EventArgs e)
        {
            textBox1.Text = person.Ad;
            textBox2.Text = person.Soyad;
            textBox3.Text = person.OzelKod;
            textBox4.Text = person.Telefon;
            textBox5.Text = person.Adres;
            textBox6.Text = person.Bakiye.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.Ad = textBox1.Text;
            person.Soyad = textBox2.Text;
            person.OzelKod = textBox3.Text;
            person.Telefon = textBox4.Text;
            person.Adres = textBox5.Text;
            person.Bakiye = double.Parse(textBox6.Text);
            dataBase.DataUpdate(person);
            this.Hide();
        }
    }
}
