using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;
namespace GeneratoreQR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var myData = QG.CreateQrCode(Colleg.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(myData);
            pictureBox1.Image = code.GetGraphic(50);

            /**
            var nomef = textBox1.Text + ".png";
            var dire = textBox2.Text + "\\";

            if (dire == "\\")
            {
                dire = "C:\\Users\\Huawei\\Desktop\\alius\\servizio\\QR\\";
            }
       
            else if (String.Concat(dire.ToLower().Where(c => !Char.IsWhiteSpace(c))) == "desktop\\")
            {
                dire = "C:\\Users\\Huawei\\Desktop\\";

            }

            **/
            //pictureBox1.Image = code.GetGraphic(50);
           // var percorso = dire + nomef;
            //code.GetGraphic(50).Save(percorso);
// pictureBox1.Image.Save("C:\\Users\\Huawei\\Desktop\\alius\\servizio\\QR", System.Drawing.Imaging.ImageFormat.Png);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.RestoreDirectory = true;
                sfd.FileName = "NewQR.png";
                sfd.DefaultExt = "png";
                sfd.Filter = "PNG|*.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // StreamWriter sw = new StreamWriter(sfd.OpenFile());
                    //  var dire = sfd.InitialDirectory;
                    pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    //sw.Close();
                    //sfd.OpenFile().Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Colleg.Text = "";
            pictureBox1.Image = null;
        }
    }
}
