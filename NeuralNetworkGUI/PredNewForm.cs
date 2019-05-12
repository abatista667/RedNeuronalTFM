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
        NeuralNetwork.NeuralNetwork nn;
        List<string> predict, target;
        DataTable alldt;
        public PredNewForm(NeuralNetwork.NeuralNetwork n, List<string> X, List<string> Y, DataTable dt)
        {
            table = new DataTable();
            X.ForEach(x => table.Columns.Add(x.Trim()));
            Y.ForEach(y => {
                var c = new DataColumn(y.Trim());
                table.Columns.Add(c);
            });
            nn = n;
            predict= X;
            target = Y;
            alldt = dt;
            InitializeComponent();
        }

        private void PredNewForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in alldt.Rows)
            {
                var nr = table.NewRow();
                predict.ForEach(x=>{
                    nr[x.Trim()] = r[x.Trim()];
                });

                table.Rows.Add(nr);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<double> X,  Y;

            foreach (DataRow r in table.Rows)
            {
                X = new List<double>();
                Y = new List<double>();
                predict.ForEach(i => X.Add(double.Parse(r[i.Trim()].ToString())));
                Y = nn.Predict(X.ToArray()).ToList();

                for (int i = 0; i < Y.Count; i++)
                {
                    r[target[i].Trim()] = Y[i];
                }

            }

            MessageBox.Show(table.Rows.Count.ToString());
        }
    }
}
