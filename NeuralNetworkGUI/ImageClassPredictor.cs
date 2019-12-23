using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkGUI
{
    public partial class ImageClassPredictor : Form
    {
        Image image;
        NeuralNetwork.NeuralNetwork nn;
        public ImageClassPredictor()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            image = Bitmap.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = image;
            if (nn != null) button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog2.FileName;
                nn = new NeuralNetwork.NeuralNetwork();
                nn.Load(openFileDialog2.FileName);
                if(image != null) button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int width = int.Parse(tbW.Text);
            int height = int.Parse(tbH.Text);

            var resized = ResizeBitmap(image, width, height);
            double[] arrData = FlatImageRgb(resized);
            var prediction = nn.Predict(arrData);
            lbPrediction.Text = "";
            prediction.ToList().ForEach(i => lbPrediction.Text += i.ToString() + " ");
            button2.Enabled = false;
        }

        public Bitmap ResizeBitmap(Image bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private double[] FlatImageRgb(Bitmap image)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    result.Add(pixel.R);
                    result.Add(pixel.G);
                    result.Add(pixel.B);
                }
            }
            return result.ToArray();
        }
    }
}
