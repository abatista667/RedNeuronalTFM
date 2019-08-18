using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork;

namespace NeuralNetworkGUI
{
    public partial class PredGridForm : Form
    {
        public PredGridForm(double[][] y, double[][] ypred)
        {
            InitializeComponent();

            Y= y;
            Ypred = ypred;
        }
        double[][] Y;
        double[][] Ypred;
        double loss_sum;
        double loss_mean;
        private void PredGridForm_Load(object sender, EventArgs e)
        {
            double[][] loss = new double[Y.Length][];
            var dt = new DataTable();

            for (int i = 0; i < Y.First().Length; i++)
            {
                dt.Columns.Add("Y"+i);
            }
            for (int i = 0; i < Y.First().Length; i++)
            {
                dt.Columns.Add("Ypred" + i);

            }
            dt.Columns.Add("perdida");

            for (int j = 0; j < Y.Length; j++)
            {
                var r = dt.NewRow();
                loss[j] = new double[Y.First().Length];

                for (int i = 0; i < Y.First().Length; i++)
                {
                    loss[j][i] = Y[j][i] - Ypred[j][i];
                    r["Y"+i] = Y[j][i];
                    r["Ypred" + i] = Ypred[j][i];
                }
                r["perdida"] = Utils.Sum(loss[j]);
                dt.Rows.Add(r);
            }

            loss_sum = Utils.Sum(loss);
            loss_mean =  Utils.Mean(loss);
            label1.Text= "Perdida acumulada: "+loss_sum;
            label2.Text = "Perdida media: " + loss_mean;

            dataGridView1.DataSource = dt;
        }
    }
}
