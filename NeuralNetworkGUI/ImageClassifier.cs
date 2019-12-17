using NeuralNetwork;
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
        List<double> reportedLoss;
        NeuralNetwork.NeuralNetwork nn;
        BackgroundWorker worker;
        DateTime start;
        List<string> XFiles;
        List<string> XLabels;

        public ImageClassifier()
        {
            InitializeComponent();
            flattenTrainingData = new List<double[]>();
            flattenTestingData = new List<double[]>();
            XFiles = new List<string>();
            XLabels = new List<string>();
            YTest = new List<double[]>();
            YTrain = new List<double[]>();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;

            worker.ProgressChanged += Worker_ProgressChanged;

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            reportedLoss = new List<double>();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Enabled = true;
            progressBar1.Value = 100;
            MessageBox.Show("Entrenamineto completado");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            var state = (NeuralNetwork.ReportProgressModel)e.UserState;

            lbperdida.Text = $"Perdida: {state.loss}";
            lbepoch.Text = $"epoch: {state.epoch}";
            reportedLoss.Add(state.loss);
            chart1.Series[0].Points.DataBindY(reportedLoss);
            lbtiempo.Text = (DateTime.Now - start).ToString();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            start = DateTime.Now;
            nn.Fit(flattenTrainingData.ToArray(), YTrain.ToArray(), worker);
        }

        private void InitializeNet(bool empty = true)
        {
            int epoch = int.Parse(tbEpoch.Text);
            int batches = int.Parse(tbBatches.Text);
            double leraningRate = double.Parse(tbLearningRate.Text);

            var hl = tbHidden.Text.Split(',').ToList();

            List<Layer> layers = new List<Layer>();

            if (empty)
                layers = new List<Layer>(){
            new Layer(flattenTrainingData.First().Length),
            };

            hl.ForEach(x => layers.Add(new Layer(int.Parse(x), ACTIVATION.RELU)));

            var activationOutput = ACTIVATION.SIGMOID;
            var loss = LOSS.BINARY_CROSS_ENTROPY;

            if (YTrain.First().Length > 1)
            {
                activationOutput = ACTIVATION.SOFTMAX;
                loss = LOSS.CATEGORICAL_CROSS_ENTROPY;
            }

            layers.Add(new Layer(YTrain.First().Length, activationOutput));


            var optimizer = Optimizers.ByName[cbOptimizer.Text];

            nn = new NeuralNetwork.NeuralNetwork(layers, leraningRate, epoch, loss, false, batches,
                                       optimizer: optimizer, checkPointPath: tbCheckpoint.Text);

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
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                loadTestingSet();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ckReiniciar.Checked || nn == null)
                InitializeNet();

            int epoch = int.Parse(tbEpoch.Text);
            int batches = int.Parse(tbBatches.Text);
            double leraningRate = double.Parse(tbLearningRate.Text);

            nn.BatchSize = batches;
            nn.LearningRate = leraningRate;
            nn.Epoch = epoch;
            nn.CheckPointPath = tbCheckpoint.Text;

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
            button2.Enabled = false;
        }

        private void loadTrainingSet()
        {
            int width = int.Parse(tbWidth.Text);
            int height = int.Parse(tbHeigth.Text);

            tbPath.Text = folderBrowserDialog1.SelectedPath;
            foreach (var path in Directory.GetDirectories(tbPath.Text))
            {
                var parts = path.Split('\\');
                var label = parts[parts.Length - 1].Split('-').Select(x => double.Parse(x));
                foreach (var fileName in Directory.GetFiles(path))
                {
                    var image = Bitmap.FromFile(fileName);
                    var resized = ResizeBitmap(image, width, height);
                    double[] arrData = FlatImageRgb(resized);
                    flattenTrainingData.Add(arrData);
                    YTrain.Add(label.ToArray());
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
                foreach (var fileName in Directory.GetFiles(path))
                {
                    var image = Bitmap.FromFile(fileName);
                    var resized = ResizeBitmap(image, width, height);
                    double[] arrData = FlatImageRgb(resized);
                    flattenTestingData.Add(arrData);
                    YTest.Add(label.ToArray());
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

        private void button5_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbCheckpoint.Text = folderBrowserDialog3.SelectedPath;
                nn.CheckPointPath = tbCheckpoint.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            InitializeNet(false);
            nn.Load(openFileDialog1.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float res = nn.Evaluate(flattenTestingData.ToArray(), YTest.ToArray());
            MessageBox.Show("porcentaje de aciertos: " + res);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            reportedLoss = new List<double>();
        }
    }
}
