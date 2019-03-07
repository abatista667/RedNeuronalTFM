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

        private void PredGridForm_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();

            for (int i = 0; i < Y.First().Length; i++)
            {
                dt.Columns.Add("Y"+i);
            }
            for (int i = 0; i < Y.First().Length; i++)
            {
                dt.Columns.Add("Ypred" + i);
                dt.Columns.Add("perdida" + i);
            }

            for (int j = 0; j < Y.Length; j++)
            {
                var r = dt.NewRow();

                for (int i = 0; i < Y.First().Length; i++)
                {
                    r["Y"+i] = Y[j][i];
                    r["Ypred" + i] = Ypred[j][i];
                    r["perdida" + i] = Y[j][i] - Ypred[j][i];
                    dt.Rows.Add(r);
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
