using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace AliOzturkProject
{
    public class CRUD
    {




        public Image LoadImageFromUrl(string url)
        {
            try
            {


                using (var webClient = new System.Net.WebClient())
                {
                    var stream = webClient.OpenRead(url);
                    return Image.FromStream(stream);
                }
            }
            catch(Exception ex) {
            MessageBox.Show(ex.Message);
                return null;
            }


    }
    }
}