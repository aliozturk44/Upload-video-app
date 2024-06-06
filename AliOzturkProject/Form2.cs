using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace AliOzturkProject
{
    public partial class Form2 : Form
    {
        string VideoID;
        string VideoLink;
        string VideoDesc;
        string VideoDate;
        String VideoDelete;
        int i = 0;
        int a = 0;
        int b = 0;
        CRUD crud = new CRUD();
        
        public Form2()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            string[] rows = File.ReadAllLines("Video.csv");

            foreach (string row in rows)
            {
                string[] parts = row.Split('|');

                if (parts[0] == "")
                {

                }
                else if (parts[4] == "1")
                {
                    b = b + 1;
                    continue;
                }
                else
                {
                    try
                    {
                        ListViewItem item = new ListViewItem();
                        imageList1.Images.Add(crud.LoadImageFromUrl("https://img.youtube.com/vi/" + parts[0] + "/default.jpg"));
                        listView1.SmallImageList = imageList1;
                        item.ImageIndex = i;
                        item.SubItems.Add(parts[2]);
                        item.SubItems.Add(parts[3]);
                        listView1.Items.Add(item);
                        i = i + 1;
                    }
                    catch (Exception ex) {
                        MessageBox.Show("vidyo yüklenirken hata oluştu");
                    }
                    
                }

            }
         lblInform.Text = "There are " + (listView1.Items.Count) + " saved videos. There are also " + (b) + " deleted videos. Last updatedate is  " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            b = 0;
            picBox.Image = null;
            btnDelete.Enabled = false;
            btnOpen.Enabled = false;
            btnUpdate.Enabled = false;
            lblCreationTime.Text = "";
            lblDescription.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("", 25);
            listView1.Columns.Add("Video Adı", 265);
            listView1.Columns.Add("Eklenme Tarihi", 86);

            loadData();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (listView1.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnOpen.Enabled = true;
                btnUpdate.Enabled = true;

                

                string[] rows = File.ReadAllLines("Video.csv");

                foreach (string row in rows) {
                    string[] parts = row.Split('|');

                   
                    if (parts[2].ToString() == listView1.SelectedItems[0].SubItems[1].Text) {
                        lblDescription.Text = listView1.SelectedItems[0].SubItems[1].Text;
                        lblCreationTime.Text = "Oluşturulma tarihi: " + listView1.SelectedItems[0].SubItems[2].Text;
                        picBox.Load("https://img.youtube.com/vi/" + parts[0] + "/default.jpg");
                        VideoLink = parts[1].ToString();
                        VideoID = parts[0].ToString();
                        VideoDesc = parts[2].ToString();
                        VideoDate = parts[3].ToString();
                        VideoDelete = parts[4].ToString();
                        
                    }
                    
                }

                






            }


        }

        private void picBox_Click(object sender, EventArgs e)
        {
            Process.Start(VideoLink);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process.Start(VideoLink);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            
            form4.VideoID = VideoID;
            form4.VideoLink = VideoLink;
            form4.VideoDesc = VideoDesc;
            form4.VideoDate = VideoDate;
            form4.VideoDelete = VideoDelete;
            form4.ShowDialog();
            this.Close();
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string filePath = "Video.csv"; // Path to the CSV file
            string newLine = VideoID + "|" + VideoLink + "|" + VideoDesc + "|" + DateTime.Now.ToString("dd.MM.yyyy") + "|" + "1";
            string[] rows = File.ReadAllLines("Video.csv");
            foreach (string row in rows)
            {
                string[] parts = row.Split('|');
                if (parts[2] == VideoDesc)
                {
                    break;
                }

                a = a + 1;
            }

            if (File.Exists(filePath))
            {
                // Read all lines of the file
                string[] lines = File.ReadAllLines(filePath);

                // Update the first line
                if (lines.Length > 0)
                {
                    lines[a] = newLine;
                    a = 0;
                }


                // Write all lines back to the file
                File.WriteAllLines(filePath, lines, Encoding.UTF8);

                MessageBox.Show("Vidyo Başarıyla silindi", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            loadData();
        }
    }
}
