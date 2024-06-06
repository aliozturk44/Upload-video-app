using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliOzturkProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewDesc.Text.Contains("|"))
            {
                MessageBox.Show("Vidyo açıklaması | karakterini içeremez.");
            }
            else if (string.IsNullOrWhiteSpace(txtNewDesc.Text) || string.IsNullOrWhiteSpace(txtNewId.Text) || string.IsNullOrWhiteSpace(txtNewLink.Text))
            {
                MessageBox.Show("Alanlar boş olamaz!");
            }
            else
            {
                FileStream file = new FileStream("Video.csv", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                string db = sr.ReadLine();


                if (db == "")
                {
                    sr.Close();
                    StreamWriter sw = new StreamWriter("Video.csv");

                    string metin = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                    sw.WriteLine(metin);
                    sw.Close();
                    MessageBox.Show("Vidyo kaydedildi", "Vidyo kayıt işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sr.Close() ;
                    FileStream fs = new FileStream("Video.csv", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    string metin = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                    sw.WriteLine(metin);
                    sw.Close();
                    MessageBox.Show("Vidyo kaydedildi", "Vidyo kayıt işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    this.Close();
                }



          /*      FileStream fs = new FileStream("Video.csv", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                string metin = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                        sw.WriteLine(metin);
                        sw.Close();
                        MessageBox.Show("Vidyo kaydedildi", "Vidyo kayıt işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
          */
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNewId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewDesc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
