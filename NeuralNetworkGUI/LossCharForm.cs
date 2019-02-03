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
    public partial class LossCharForm : Form
    {
        double[] _loss;
        public LossCharForm(double[] loss)
        {
            InitializeComponent();
            _loss = loss;

            chart1.Series[0].Points.DataBindY(_loss);
        }
    }
}
