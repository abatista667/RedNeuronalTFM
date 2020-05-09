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
    public partial class EvaluationChart : Form
    {
        float _accuracy;
        public EvaluationChart(float accuracy)
        {
            InitializeComponent();
            _accuracy = accuracy * 100;
        }

        private void EvaluationChart_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(0, _accuracy);
            textBox1.Text = $"{_accuracy.ToString("0.00")}%";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
