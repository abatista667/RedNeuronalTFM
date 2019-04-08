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

        List<string> predictFields, targetFields;

        private void Button1_Click(object sender, EventArgs e)
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

            init = false;
        }

        private void Button2_Click(object sender, EventArgs e)
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

            init = false;
        }

        private void MainWindows_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var lines = File.ReadAllLines(openFileDialog1.FileName);
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

            if (!init)
            {
                predictFields = tbPredictoras.Text.Split(',').ToList();
                targetFields = tbObjetivos.Text.Split(',').ToList();
            }

            int countTest = int.Parse(tbTest.Text);
            X = new double[dataTable.Rows.Count][];
            Y = new double[dataTable.Rows.Count][];
            Xtest = new double[countTest][];
            Ytest = new double[countTest][];
            Ypred = new double[countTest][];

            int index = 0;
            //inizializar valores X Y
            var rand = new Random();
            var result = dataTable.AsEnumerable().OrderBy(r => rand.Next());
            foreach (DataRow r in result)
            {
                var tmpX = new List<double>();
                var tmpY = new List<double>();

                foreach (var f in predictFields)
                {
                    tmpX.Add(Convert.ToDouble(r[f.Trim()].ToString()));
                }

                foreach (var f in targetFields)
                {
                    tmpY.Add(Convert.ToDouble(r[f.Trim()].ToString()));
                }

                X[index] = tmpX.ToArray();
                Y[index] = tmpY.ToArray();

                index++;
            }
            //separar en train y test
            var Xlist = X.ToList();
            var Ylist = Y.ToList();
            for (int i = 0; i < countTest; i++)
            {
                Xtest[i] = Xlist[i];
                Xlist.RemoveAt(i);

                Ytest[i] = Ylist[i];
                Ylist.RemoveAt(i);
            }

            X = Xlist.ToArray();
            Y = Ylist.ToArray();

            if (!init)
            {
                InitializeNet();
            }

            //try
            //{
            model = nn.Fit(X, Y);
            label8.Text = $"Perdida: {model.Errors[model.Errors.Count - 1]}";

            MessageBox.Show("Entrenamiento Completado");



            for (int i = 0; i < Ytest.Length; i++)
            {
                Ypred[i] = nn.Predict(Xtest[i]);
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}
