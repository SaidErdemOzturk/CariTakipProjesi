using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace CariTakipProjesi
{
    class SqlDatabase : IDataBase
    {
        DataGridView dataGridView;
        private OleDbCommand command;
        private DataTable dt;
        private OleDbDataAdapter adapter;
        private OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database.accdb");
        public SqlDatabase(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }
        public SqlDatabase()
        {

        }
        public void DataAdd(IPerson person,IIslem islem)
        {
            baglanti.Open();
            MessageBox.Show(person.Id.ToString());
            command = new OleDbCommand("INSERT INTO "+person.Tablo+" (Id,Ad,Soyad,OzelKod,Telefon,Adres,Bakiye) VALUES('"+person.Id+"','"+person.Ad+ "','" + person.Soyad + "','" + person.OzelKod + "','" + person.Telefon + "','" + person.Adres + "','"+person.Bakiye+"')", baglanti);
           
            OleDbCommand command1 = new OleDbCommand("INSERT INTO "+islem.TabloIslem+" (Id,Tarih,Aciklama,ToplamFiyat) VALUES('"+person.Id+"','"+ DateTime.Today.ToString("d.MM.yyyy") + "','Cari Kart Oluşturma','"+person.Bakiye+"')", baglanti);
            command1.ExecuteNonQuery();
            command1.Dispose();

            command.ExecuteNonQuery();
            command.Dispose();
            baglanti.Close();
        }

        public void DataDelete(IPerson person)
        {
            baglanti.Open();
            command = new OleDbCommand("DELETE FROM "+person.Tablo+" WHERE Id=@id", baglanti);
            command.Parameters.AddWithValue("@id", person.Id);
            command.ExecuteNonQuery();
            command.Dispose();
            baglanti.Close();

        }

        public void DataSearch(IPerson person ,string metin,string tur)
        {
            baglanti.Open();
            adapter = new OleDbDataAdapter("SELECT * FROM "+person.Tablo+" WHERE "+tur+" LIKE '%" + metin + "%'", baglanti);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            adapter.Dispose();
            baglanti.Close();
        }

        public void DataUpdate(IPerson person)
        {
            baglanti.Open();
            command = new OleDbCommand("UPDATE "+person.Tablo+" SET Ad='" + person.Ad + "',Soyad='"+person.Soyad+"',OzelKod='" + person.OzelKod + "',Telefon='" + person.Telefon + "',Adres='" + person.Adres + "' WHERE Id=@id", baglanti);
            command.Parameters.AddWithValue("@id", person.Id);
            command.ExecuteNonQuery();
            command.Dispose();
            baglanti.Close();
        }

        public void GetAll(IPerson person)
        {
            baglanti.Open();
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT * FROM "+person.Tablo+"", baglanti);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            adapter.Dispose();
            baglanti.Close();
        }

        public void GetIslem(IPerson person,IIslem islem)
        {
            baglanti.Open();
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT * FROM "+islem.TabloIslem+" WHERE Id=" + person.Id + "", baglanti);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            adapter.Dispose();
            baglanti.Close();
        }

        public void IslemAdd(IIslem islem, IPerson person)
        {
            baglanti.Open();
            command = new OleDbCommand("INSERT INTO "+islem.TabloIslem+" (Id,Tarih,Fiyat,Miktar,MalCinsi,Aciklama,ToplamFiyat) VALUES('" + islem.Id + "','" + islem.Tarih + "','" + islem.Fiyat + "','" + islem.Miktar + "','" + islem.MalCinsi+ "','"+islem.Aciklama+"','"+islem.ToplamFiyat+"')", baglanti);
            person.Bakiye = person.Bakiye + islem.ToplamFiyat;
            OleDbCommand command1 = new OleDbCommand("Update "+person.Tablo+" Set Bakiye='"+person.Bakiye+"' WHERE Id=@id", baglanti);
            command1.Parameters.AddWithValue("@id", person.Id);
            command.ExecuteNonQuery();
            command1.ExecuteNonQuery();
            command1.Dispose();
            command.Dispose();
            baglanti.Close();

        }

        public void IslemUpdate(IIslem islem,IPerson person)
        {
            baglanti.Open();
            
            command = new OleDbCommand("UPDATE "+ islem.TabloIslem +" SET Tarih='" +islem.Tarih + "',Fiyat='" + islem.Fiyat + "',Miktar='" + islem.Miktar + "',MalCinsi='" + islem.MalCinsi+ "',Aciklama='" + islem.Aciklama+ "',ToplamFiyat='"+islem.ToplamFiyat+ "' WHERE Kimlik="+islem.Kimlik+"", baglanti);
            command.ExecuteNonQuery();
            command.Dispose();
            MessageBox.Show(person.Id.ToString()+person.Tablo+person.Bakiye.ToString());
            OleDbCommand command1 = new OleDbCommand("UPDATE " +person.Tablo + " SET Bakiye='" + person.Bakiye+ "' WHERE Id="+person.Id+"", baglanti);

            command1.ExecuteNonQuery();
            command1.Dispose();
            baglanti.Close();
        }

        public void IslemDelete(IIslem islem,IPerson person)
        {
            baglanti.Open();
            command = new OleDbCommand("DELETE FROM " + islem.TabloIslem + " WHERE Kimlik="+islem.Kimlik+"", baglanti);
            command.ExecuteNonQuery();
            command.Dispose();
            OleDbCommand command1 = new OleDbCommand("UPDATE " + person.Tablo + " SET Bakiye='" + person.Bakiye + "' WHERE Id=" + person.Id + "", baglanti);
            command1.ExecuteNonQuery();
            command1.Dispose();
            baglanti.Close();
        }
    }
}
