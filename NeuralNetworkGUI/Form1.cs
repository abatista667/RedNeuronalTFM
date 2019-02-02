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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NeuralNetworkBase nn;

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\ariel batista\Documents\dataset\Advertising.csv";
            List<double> X, Y;
            var lines = File.ReadAllLines(path);
            X = new List<double>();
            Y = new List<double>();
            var Ypre = new List<double>();
            foreach (var line in lines.Skip(1))//skipt the header
            {
                var fields = line.Split(',');
                X.Add(double.Parse(fields[0]));
                Y.Add(double.Parse(fields[3]));
            }

            var layers = new List<Layer>(){
            new Layer(1),
            new Layer(2),
            new Layer(2),
            new Layer(1)
            };
            nn = new NeuralNetworkBase(layers, 0.0000001, 200, "MSE", false, 20);

            var xArr = arrayToMatrixArray(X.ToArray());
            var model = nn.Fit(xArr, arrayToMatrixArray(Y.ToArray()));

            foreach (var x in xArr)
            {
                Ypre.Add(nn.Predict(x)[0]);
            }

            lossChart.Series[0].Points.DataBindY(model.Errors);
        }

        double[][] arrayToMatrixArray(double[] original)
        {
            double[][] arr = new double[original.Length][];
            for (int i = 0; i < original.Length; ++i)
            {
                arr[i] = new double[1] { original[i] };
            }

            return arr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new double[] { double.Parse(textBox1.Text)};

            var y = nn.Predict(x);

            textBox2.Text = y[0].ToString();
        }
    }
}
