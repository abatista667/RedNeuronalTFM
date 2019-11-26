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

namespace NeuralNetworkGUI
{
    public partial class ImageClassifier : Form
    {
        List<double[]> flattenTrainingData;
        List<double[]> flattenTestingData;
        List<double[]> YTrain;
        List<double[]> YTest;

        public ImageClassifier()
        {
            InitializeComponent();
            flattenTrainingData = new List<double[]>();
            flattenTestingData = new List<double[]>();
            YTest = new List<double[]>();
            YTrain = new List<double[]>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadTrainingSet();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadTestingSet();
            }
        }

        private void loadTrainingSet()
        {
            int width = int.Parse(tbWidth.Text);
            int height = int.Parse(tbHeigth.Text);

            tbPath.Text = folderBrowserDialog1.SelectedPath;
            foreach (var path in Directory.GetDirectories(tbPath.Text))
            {
                var parts = path.Split('\\');
                var label = parts[parts.Length -1].Split('-').Select(x=> double.Parse(x));
                YTrain.Add(label.ToArray());
                foreach (var fileName in Directory.GetFiles(path))
                {
                    var image = Bitmap.FromFile(fileName);
                    var resized = ResizeBitmap(image, width, height);
                    double[] arrData = FlatImageRgb((Bitmap)image);
                    flattenTrainingData.Add(arrData);
                }
            }
        }
        private void loadTestingSet()
        {
            int width = int.Parse(tbWidth.Text);
            int height = int.Parse(tbHeigth.Text);

            textBox1.Text = folderBrowserDialog2.SelectedPath;
            foreach (var path in Directory.GetDirectories(textBox1.Text))
            {
                var parts = path.Split('\\');
                var label = parts[parts.Length - 1].Split('-').Select(x => double.Parse(x));
                YTest.Add(label.ToArray());
                foreach (var fileName in Directory.GetFiles(path))
                {
                    var image = Bitmap.FromFile(fileName);
                    var resized = ResizeBitmap(image, width, height);
                    double[] arrData = FlatImageRgb((Bitmap)image);
                    flattenTestingData.Add(arrData);
                }
            }
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
