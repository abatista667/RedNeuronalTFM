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
    public partial class PredNewForm : Form
    {
        DataTable table;
        NeuralNetwork.NeuralNetworkBase nn;
        List<string> predict, target;
        public PredNewForm(NeuralNetwork.NeuralNetworkBase n, List<string> X, List<string> Y)
        {
            table = new DataTable();
            X.ForEach(x => table.Columns.Add(x));
            Y.ForEach(y => {
                var c = new DataColumn(y);
                table.Columns.Add(c);
            });
            nn = n;
            predict= X;
            target = Y;
            InitializeComponent();
        }

        private void PredNewForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<double> X,  Y;

            foreach (DataRow r in table.Rows)
            {
                X = new List<double>();
                Y = new List<double>();
                predict.ForEach(i => X.Add(double.Parse(r[i].ToString())));
                Y = nn.Predict(X.ToArray()).ToList();

                for (int i = 0; i < Y.Count; i++)
                {
                    r[target[i]] = Y[i];
                }

            }

            MessageBox.Show(table.Rows.Count.ToString());
        }
    }
}
