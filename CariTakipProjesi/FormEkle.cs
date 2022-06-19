using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CariTakipProjesi
{
    public partial class FormEkle : Form
    {
        IPerson person;
        IIslem islem;
        IDataBase dataBase;

        public FormEkle(IPerson person,IIslem islem)
        {
            InitializeComponent();
            dataBase = new SqlDatabase();
            this.person = person;
            this.islem = islem;
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            person.Ad = textBox1.Text;
            person.Soyad = textBox2.Text;
            person.OzelKod = textBox3.Text;
            person.Telefon = textBox4.Text;
            person.Adres = textBox5.Text;
            person.Bakiye = double.Parse(textBox6.Text);
            dataBase.DataAdd(person, islem);
            this.Hide();
        }

        private void FormEkle_Load(object sender, EventArgs e)
        {
            textBox7.Text = person.Id.ToString();
        }

        private void FormEkle_Leave(object sender, EventArgs e)
        {
            dataBase.GetAll(person);
        }
    }

}
