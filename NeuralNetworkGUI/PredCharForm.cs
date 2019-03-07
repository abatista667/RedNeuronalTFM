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
    public partial class PredCharForm : Form
    {
        double[][] Y;
        double[][] Ypred;
        public PredCharForm(double[][] y, double[][] ypred)
        {
            InitializeComponent();
            Y = y;
            Ypred = ypred;

            int series = y.First().Length;

            for (int i = 0; i < series; i++)
            {
                if (i > 0) chart1.Series.Add("Y ");

                for (int j = 0; j < y.Length; j++)
                {
                    chart1.Series[i].Points.AddY(y[j][i]);
                }

                chart1.Series[i].Name = "Y - " + i;
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            for (int i = series; i < series *2; i++)
            {
                if (i > 0) chart1.Series.Add("Ypred ");

                for (int j = 0; j < y.Length; j++)
                {
                    chart1.Series[i].Points.AddY(ypred[j][i - series]);
                }

                chart1.Series[i].Name = "Ypred - " + i;
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            //chart1.Series[0].Points.DataBindY(_loss);
        }
    }
}
