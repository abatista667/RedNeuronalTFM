using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkClassification
{
    public partial class MainWindows : Form
    {
        public MainWindows()
        {
            InitializeComponent();
        }

        NeuralNetworkBase nn;
        DataTable dataTable;
        NeuralNetworkModel model;
        double[][] Y, X, Xtest, Ytest;
        double[][] Ypred;
        bool init = false;

        private void InitializeNet()
        {
            int epoch = int.Parse(tbEpoch.Text);
            int batches = int.Parse(tbBatches.Text);
            double leraningRate = double.Parse(tbLearningRate.Text);

            var hl = tbHidden.Text.Split(',').ToList();
            
            var layers = new List<Layer>(){
            new Layer(X.First().Length),
            };
            
            hl.ForEach(x => layers.Add(new Layer(int.Parse(x))));

            layers.Add(new Layer(Y.First().Length, ACTIVATION.SIGMOID));

            nn = new NeuralNetworkBase(layers, leraningRate, epoch, LOST.CATEGORICAL_CROSS_ENTROPY, false, batches,
                                       optimizer: OPTIMIZER.SGD);

            init = true;
        }

        private void CargarDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
