using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
namespace Vekka
{
    public partial class Vekka : Form
    {
        public Vekka()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
      
        public DataTable tablo = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        SqlCommand kmt2 = new SqlCommand();
        string yeniyol = "";
        int id;
        private string secili_id;
        
        private void Vekka_Load(object sender, EventArgs e)
        {
            listele();

        }
        public void listele()
        {
            try
            {
                tablo.Clear();
                
                SqlDataAdapter adtr = new SqlDataAdapter("select * From veriler order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();
                
                
                                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                //datagridview1'deki tüm satırı seç    
                                dataGridView1.Columns[0].Visible = false;
                                dataGridView1.Columns[8].Visible = false;

                                dataGridView1.Columns[1].HeaderText = "VEKALET ID";
                                dataGridView1.Columns[2].HeaderText = "VEKALET NO";
                                dataGridView1.Columns[3].HeaderText = "ADI";
                                dataGridView1.Columns[4].HeaderText = "SOYADI";
                                dataGridView1.Columns[5].HeaderText = "NOTER ADI";
                                dataGridView1.Columns[6].HeaderText = "YEVMİYE NO";
                                dataGridView1.Columns[7].HeaderText = " TARİH";

                                dataGridView1.Columns[1].Width = 100;
                                dataGridView1.Columns[2].Width = 100;
                                dataGridView1.Columns[3].Width = 80;
                                dataGridView1.Columns[4].Width = 80;
                                dataGridView1.Columns[5].Width = 100;
                                dataGridView1.Columns[6].Width = 100;
                                dataGridView1.Columns[7].Width = 100;



            }
            catch(Exception hata)
            {
                
                MessageBox.Show(hata.Message);
                throw ;
            }
        }
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            pictureBox1.ImageLocation = "add1.png";

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "";
           // axShockwaveFlash1.LoadMovie(0, "");  // Bu kısma animasyonun yolu yazılacak
            //axShockwaveFlash1.Loop = false;                 // Bu
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "") errorProvider1.SetError(textBox1, "Boş geçilmez");
                else errorProvider1.SetError(textBox1, "");
                if (textBox2.Text.Trim() == "") errorProvider1.SetError(textBox2, "Boş geçilmez");
                else errorProvider1.SetError(textBox2, "");
                if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez");
                else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, "");
                if (textBox5.Text.Trim() == "") errorProvider1.SetError(textBox5, "Boş geçilmez");
                else errorProvider1.SetError(textBox5, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox6, "Boş geçilmez");
                else errorProvider1.SetError(textBox6, "");
                if (maskedTextBox1.Text.Trim() == "") errorProvider1.SetError(maskedTextBox1, "Boş geçilmez");
                else errorProvider1.SetError(maskedTextBox1, "");

                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && maskedTextBox1.Text.Trim() != "")
                {
                    
                    kmt.Connection = bag.baglan();
                    kmt.CommandText = "INSERT INTO veriler(vekalet_id,vekalet_no,ad,soyad,noter_adi,yevmiye_no,tarih,resim) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + maskedTextBox1.Text + "','"+ Path.GetFileName(yeniyol) + "') ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();

                    kmt2.Connection = bag.baglan();
                    kmt2.CommandText = kmt.CommandText = "INSERT INTO iletisim(vekalet_id,vekalet_no,ad,soyad,resim) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Path.GetFileName(yeniyol) + "') ";
                    kmt2.ExecuteNonQuery();
                    kmt2.Dispose();
                    listele();    
                    temizle();
                }

            }
            catch(Exception hata)
            {
                MessageBox.Show("Kayıtlı Vekalet Id !! Öncelikle kayıtlı veriyi güncelleyiniz yada Siliniz !"+hata.Message);
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                pictureBox1.ImageLocation = Application.StartupPath + "\\images\\" + dataGridView1.CurrentRow.Cells[8].Value.ToString();
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                secili_id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
               
            }
            catch
            {

              ;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                 
                    kmt.Connection = bag.baglan();
                    kmt.CommandText = "DELETE from veriler WHERE vekalet_id='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    
                   

                    kmt2.Connection = bag.baglan();
                    kmt2.CommandText= "DELETE from dbo.iletisim WHERE dbo.iletisim.vekalet_id='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' ";
                    kmt2.ExecuteNonQuery();
                    kmt2.Dispose();
                    listele();
                    temizle();
                    MessageBox.Show("Silme İşleminiz Başarılı");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && maskedTextBox1.Text.Trim() != "")
            {

                string sorgu = "UPDATE veriler SET vekalet_no='" + maskedTextBox1.Text + "',ad='" + maskedTextBox1.Text + "',soyad='" + textBox4.Text + "',noter_adi='" + textBox5.Text + "',yevmiye_no='" + textBox6.Text +"',tarih='"+maskedTextBox1.Text+"',resim='" + Path.GetFileName(yeniyol)+ "' WHERE id="+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand kmt = new SqlCommand(sorgu, bag.baglan());
                bag.baglan();
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                listele();
                //iletişim verileri
                try
                {
                string sorgu2 = "Update iletisim set vekalet_no='"+textBox2.Text+"',ad='"+textBox3.Text+"',soyad='"+textBox4.Text+"',resim='" + Path.GetFileName(yeniyol) + "' WHERE vekalet_id=" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlCommand kmt2 = new SqlCommand(sorgu2,bag.baglan());
                bag.baglan();
                kmt2.ExecuteNonQuery();
                kmt2.Dispose();

                }
                catch (Exception hata)
                {
                    MessageBox.Show("hata aldınız"+hata.Message);
                    throw;
                }

                MessageBox.Show("Güncelleme İşlemi Başarı İle Tamamlandı");

            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız !");
            }

}

        private void button4_Click(object sender, EventArgs e)
        {
            



            DosyaAc.Filter = "Resim Dosyası |*.jpg;*.nef;*.png | Tüm Dosyalar |*.*";
            DosyaAc.ShowDialog();
            string dosyayolu = DosyaAc.FileName;
            yeniyol = Application.StartupPath + "\\images\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
        //  pictureBox1.ImageLocation = dosyayolu;
         // axAcroPDF1.LoadFile(dosyayolu);  // Bu kısma animasyonun yolu yazılacak
                           // Bu
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
          
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From veriler where vekalet_id like'%" + textBox7.Text + "%'or vekalet_no like '%" + textBox7.Text + "%'or ad like '%" + textBox7.Text + "%'or soyad like '%"+textBox7.Text+"%'or noter_adi like '%"+textBox7.Text+"%'or yevmiye_no like '%"+textBox7.Text+"%'or tarih like'%"+textBox7.Text+"%'", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;

                dataGridView1.Columns[1].HeaderText = "VEKALET ID";
                dataGridView1.Columns[2].HeaderText = "VEKALET NO";
                dataGridView1.Columns[3].HeaderText = "ADI";
                dataGridView1.Columns[4].HeaderText = "SOYADI";
                dataGridView1.Columns[5].HeaderText = "NOTER ADI";
                dataGridView1.Columns[6].HeaderText = "YEVMİYE NO";
                dataGridView1.Columns[7].HeaderText = " TARİH";

                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 100;



            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }
          
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iletisim ilet = new iletisim();
            ilet.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Text = dateTimePicker1.Value.ToString();
        }
    }
    }
