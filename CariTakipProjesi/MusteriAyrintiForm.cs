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
    public partial class MusteriAyrintiForm : Form
    {
        IDataBase dataBase;

        IPerson person;
        IIslem islem;
        public MusteriAyrintiForm(IPerson person,IIslem islem)
        {
            InitializeComponent();
            dataBase = new SqlDatabase(dataGridView1);
            this.person = person;
            this.islem = islem;
        }

        private void MusteriAyrintiForm_Load(object sender, EventArgs e)
        {
            label8.Text = person.Ad;
            label9.Text = person.Soyad;
            label10.Text = person.OzelKod;
            label11.Text = person.Telefon;
            label12.Text = person.Adres;
            label2.Text = person.Bakiye.ToString();
            dataBase.GetIslem(person, islem);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IslemEkleForm islemEkleForm = new IslemEkleForm(person,islem);
            islemEkleForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IslemOdemeForm islemOdemeForm = new IslemOdemeForm(person,islem);
            islemOdemeForm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            islem.Kimlik = int.Parse(dataGridView1.CurrentRow.Cells["Kimlik"].Value.ToString());
            islem.Id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            islem.Tarih = dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["MalCinsi"].Value.ToString() == "")
            {
                islem.MalCinsi = "";
                islem.Miktar = 1;
                islem.Fiyat = 1;
                
            }
            else
            {
                islem.MalCinsi = dataGridView1.CurrentRow.Cells["MalCinsi"].Value.ToString();
                islem.Miktar = double.Parse(dataGridView1.CurrentRow.Cells["Miktar"].Value.ToString());
                islem.Fiyat = double.Parse(dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString());

            }
            islem.Aciklama = dataGridView1.CurrentRow.Cells["Aciklama"].Value.ToString();
            islem.ToplamFiyat = islem.Fiyat;
            
            IslemGuncelleForm islemGuncelleForm = new IslemGuncelleForm(person,islem);
            islemGuncelleForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            islem.Kimlik = int.Parse(dataGridView1.CurrentRow.Cells["Kimlik"].Value.ToString());
            islem.Fiyat = double.Parse(dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString());
            islem.Miktar = double.Parse(dataGridView1.CurrentRow.Cells["Miktar"].Value.ToString());
            islem.ToplamFiyat = islem.Miktar * islem.Fiyat;
            person.Bakiye = person.Bakiye - islem.ToplamFiyat;
            dataBase.IslemDelete(islem,person);
        }
    }
}
