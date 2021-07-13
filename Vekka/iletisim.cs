using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Threading.Tasks;
using System.Diagnostics;
namespace Vekka
{
    public partial class iletisim : Form
    {
        public iletisim()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        static string SkypeID = "";
        public DataTable tablo = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();

        private void iletisim_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            doldur();
            temizle();
        }

        void goruntule()
        {
            try
            {
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();



            }
            catch
            {

                ;
            }
        }
        void temizle()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        void doldur()
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From iletisim order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Vekalet ID";
                dataGridView1.Columns[2].HeaderText = "Vekalet No";
                dataGridView1.Columns[3].HeaderText = "ADI";
                dataGridView1.Columns[4].HeaderText = "SOYADI";
             

                dataGridView1.Columns[1].Width = 95;
                dataGridView1.Columns[2].Width = 95;
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Width = 60;
              


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                label2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                linkLabel1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                linkLabel2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                linkLabel3.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                label11.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                pictureBox5.ImageLocation = System.Windows.Forms.Application.StartupPath + "\\images\\" + dataGridView1.CurrentRow.Cells[5].Value.ToString();
              

            }
            catch
            {

                ;
            }

            goruntule();


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                string sorgu = "UPDATE iletisim SET evtel='" + maskedTextBox2.Text + "',tel='" + maskedTextBox1.Text + "',mail='" + textBox4.Text + "',facebook='" + textBox3.Text + "',twitter='"+ textBox2.Text+"',skype='"+textBox5.Text+"',yorum='"+textBox1.Text+"' WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand kmt = new SqlCommand(sorgu, bag.baglan());
                bag.baglan();
                kmt.ExecuteNonQuery();
                kmt.Dispose();
               
                //iletişim verileri

            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            MessageBox.Show("Girdiğimiz İletişim Alanları Başarı İle Güncellendi");
            textBox1.Enabled = false;
            panel1.Visible = false;
            
            goruntule();
        doldur();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
            panel1.Show();
            textBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            goruntule();

            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = true;
            panel1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Silmek İstediğiniz Kaydın Yanlızca İletişim Bilgileri Silinecektir,Yinede devam Etmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {



                    string sorgu = "UPDATE iletisim SET evtel='" + "" + "',tel='" + ""+ "',mail='" + "" + "',facebook='" + "" + "',twitter='" + ""+ "',skype='" + "" + "',yorum='" + "" + "' WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    SqlCommand kmt = new SqlCommand(sorgu, bag.baglan());
                    bag.baglan();
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    doldur();
                    //iletişim verileri



                    MessageBox.Show("Silme İşleminiz Başarılı");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vekka vkm = new Vekka();
            vkm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SkypeID = "necati.s9";
            Process.Start("callto:"+SkypeID);
        }

       
    }
}
