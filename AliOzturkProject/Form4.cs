using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace AliOzturkProject
{
    public partial class Form4 : Form
    {
        public string VideoID { get; set; }
        public string VideoLink { get; set; }
        public string VideoDesc { get; set; }
        public string VideoDate { get; set; }
        public string VideoDelete { get; set; }
        int i = 0;
        public Form4()
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

        private void Form4_Load(object sender, EventArgs e)
        {
            txtNewId.Text = VideoID;
            txtNewLink.Text = VideoLink;
            txtNewDesc.Text = VideoDesc;
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

                string filePath = "Video.csv"; // Path to the CSV file
                string newLine = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                string[] rows = File.ReadAllLines("Video.csv");
                foreach (string row in rows)
                {
                    string[] parts = row.Split('|');
                    if (parts[2] == VideoDesc)
                    {
                        break;
                    }

                    i = i + 1;
                }

                if (File.Exists(filePath))
                {
                    // Read all lines of the file
                    string[] lines = File.ReadAllLines(filePath);

                    // Update the first line
                    if (lines.Length > 0)
                    {
                        lines[i] = newLine;
                        i = 0;
                    }


                    // Write all lines back to the file
                    File.WriteAllLines(filePath, lines, Encoding.UTF8);

                    MessageBox.Show("Liste başarıyla güncellendi.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    this.Close();
                }








                /*
                    FileStream fs = new FileStream("Video.csv", FileMode.Open, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    string[] rows = File.ReadAllLines("Video.csv");


                    foreach (string row in rows) 
                    {
                        string[] parts = row.Split('|');
                        if (parts[2] == VideoDesc) 
                        {

                            string metin = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                            sw.WriteLine(metin);
                            sw.Close();
                            MessageBox.Show("Vidyo bilgileri güncellendi", "Vidyo kayıt işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    */

                /*    FileStream fs = new FileStream("Video.csv", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    string metin = txtNewId.Text + "|" + txtNewLink.Text + "|" + txtNewDesc.Text + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + 0;
                    sw.WriteLine(metin);
                    sw.Close();
                    MessageBox.Show("Vidyo bilgileri güncellendi", "Vidyo kayıt işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                */
            }
            }
    }
}
