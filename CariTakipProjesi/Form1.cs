using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;





namespace CariTakipProjesi
{
    public partial class Form1 : Form
    {
        IDataBase dataBase;
        IPerson person;
        IIslem islem;
        string text;
        public Form1(IPerson person, IIslem islem,string text)
        {
            InitializeComponent();
            dataBase = new SqlDatabase(dataGridView1);
            this.person = person;
            this.islem = islem;
            this.text = text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonEkle.Text = text + " Ekle";
            button1.Text = text + " Güncelle";
            button2.Text = text + " Sil";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataBase.GetAll(person);
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            int sayi = dataGridView1.Rows.Count;
            if (sayi!=1)
            {
                person.Id = int.Parse(dataGridView1.Rows[sayi - 2].Cells[0].Value.ToString());
                person.Id++;
            }
            else
            {
                person.Id = 1;
            }

            FormEkle formEkle = new FormEkle(person,islem);
            formEkle.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataBase.DataSearch(person,textBox1.Text,"Ad");
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataBase.DataSearch(person,textBox2.Text,"OzelKod");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataBase.DataSearch(person,textBox3.Text, "Soyad");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            person.Id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            person.Ad = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            person.Soyad = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            person.OzelKod = dataGridView1.CurrentRow.Cells["OzelKod"].Value.ToString();
            person.Telefon = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            person.Adres = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            person.Bakiye = double.Parse(dataGridView1.CurrentRow.Cells["Bakiye"].Value.ToString());
            MusteriAyrintiForm musteriAyrinti = new MusteriAyrintiForm(person,islem);
            musteriAyrinti.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataBase.GetAll(person);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.Id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            person.Ad = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            person.Soyad = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            person.OzelKod = dataGridView1.CurrentRow.Cells["OzelKod"].Value.ToString();
            person.Telefon = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            person.Adres = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            person.Bakiye = double.Parse(dataGridView1.CurrentRow.Cells["Bakiye"].Value.ToString());
            FormGuncelle formGuncelle = new FormGuncelle(person);
            formGuncelle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            person.Id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            dataBase.DataDelete(person);
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            dataBase.GetAll(person);
        }
    }
}
