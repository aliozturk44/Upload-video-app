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

namespace AliOzturkProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string[] query = File.ReadAllLines("Admin.csv");
            bool wrong = true;
            foreach (string part in query)
            {
                string[] parts = part.Split('|');
                if (txtUserName.Text == parts[0] && parts[1] == txtPassword.Text)
                {
                    wrong = false;
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    this.Close();
                }
                
            }

            if (wrong) {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
