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
    public partial class MainWindows : Form
    {
        public MainWindows()
        {
            InitializeComponent();
        }

        NeuralNetworkBase nn;
        DataTable dataTable;
        NeuralNetworkModel model;
        private void button1_Click(object sender, EventArgs e)
        {
            

        }


        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cargarDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFDDataSet.ShowDialog();
        }

        private void OFDDataSet_FileOk(object sender, CancelEventArgs e)
        {
            var lines = File.ReadAllLines(OFDDataSet.FileName);
            var fields = lines.First().Split(',');

             dataTable = new DataTable();

            foreach (var f in fields)
            {
                dataTable.Columns.Add(f);
            }

            foreach (var line in lines.Skip(1))//skipt the header
            {
                var data = line.Split(',');
                var row = dataTable.NewRow();

                for (int i = 0; i < fields.Length; i++)
                {
                    row[i] = data[i];
                }

                dataTable.Rows.Add(row);
            }

            dataGridView1.DataSource = dataTable;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Selected = false;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbPredictoras.Text = "";
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Selected)
                {
                    tbPredictoras.Text += c.Name + ", ";
                }
            }
            tbPredictoras.Text = tbPredictoras.Text.Substring(0, tbPredictoras.Text.Length - 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbObjetivos.Text = "";
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Selected)
                {
                    tbObjetivos.Text += c.Name + ", ";
                }
            }
            tbObjetivos.Text = tbObjetivos.Text.Substring(0, tbObjetivos.Text.Length - 2);
        }

        private void perdidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LossCharForm(model.Errors.ToArray()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var predictFields = tbPredictoras.Text.Split(',').ToList();
            var targetFields = tbObjetivos.Text.Split(',').ToList();

            double[][] X = new double[dataTable.Rows.Count][];
            double[][] Y = new double[dataTable.Rows.Count][];

            int index = 0;
            foreach (DataRow r in dataTable.Rows)
            {   
                var Xlist = new List<double>();
                var Ylist = new List<double>();

                foreach (var f in predictFields)
                {
                    Xlist.Add(Convert.ToDouble(r[f].ToString()));
                }

                foreach (var f in targetFields)
                {
                    Ylist.Add(Convert.ToDouble(r[f].ToString()));
                }

                X[index] = Xlist.ToArray();
                Y[index] = Ylist.ToArray();

                index++;  
            }

            var layers = new List<Layer>(){
            new Layer(X.First().Length),
            new Layer(16),
            new Layer(Y.First().Length)
            };
            nn = new NeuralNetworkBase(layers, 0.00000001, 200, "MSE", false, 20);

            model = nn.Fit(X, Y);
        }
    }
}
