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

        NeuralNetwork.NeuralNetwork nn;
        DataTable dataTable;
        NeuralNetworkModel model;
        double[][] Y, X, Xtest, Ytest;
        double[][] Ypred;
        bool init = false;

        ACTIVATION activationOutput;
        ACTIVATION activationHidden;
        LOSS loss;
        OPTIMIZER optimizer;

        List<string> predictFields, targetFields;
        BackgroundWorker worker, openFileWorker;
        string _filename;

        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            progressBar1.Visible = true;

            activationOutput = Activation.ByName[cbActivation.Text];
            activationHidden = Activation.ByName[cbActivationHidden.Text];
            loss = Losses.ByName[cbLoss.Text];
            optimizer = Optimizers.ByName[cbOptimizer.Text];
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
            button4.Enabled = true;
        }


        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cargarDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFDDataSet.ShowDialog();
        }

        private void OpenFileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var lines = File.ReadAllLines(_filename);
            var fields = lines.First().Split(',');

            dataTable = new DataTable();

            foreach (var f in fields)
            {
                dataTable.Columns.Add(f);
            }
            int index = 0;
            foreach (var line in lines.Skip(1))//skipt the header
            {
                var data = line.Split(',');
                var row = dataTable.NewRow();

                for (int i = 0; i < fields.Length; i++)
                {
                    row[i] = data[i];
                }

                dataTable.Rows.Add(row);
                ((BackgroundWorker)sender)
                    .ReportProgress(Convert.ToInt32(Convert.ToDouble(index++) / lines.Length));
            }
        }

        private void OFDDataSet_FileOk(object sender, CancelEventArgs e)
        {
            _filename = OFDDataSet.FileName;
            openFileWorker.WorkerReportsProgress = true;
            openFileWorker.RunWorkerAsync();
            progressBar1.Visible = true;
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

            init = false;
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

            init = false;
        }

        private void perdidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var err = model.Errors.Where(b => b < 5000).ToArray();
            new LossCharForm(err).ShowDialog();
        }


        private void BtPredict_Click(object sender, EventArgs e)
        {
            predictFields = tbPredictoras.Text.Split(',').ToList();
            targetFields = tbObjetivos.Text.Split(',').ToList();
            new PredNewForm(nn, predictFields, targetFields, dataTable).ShowDialog();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            nn.Save(saveFileDialog1.FileName);
        }

        private void MainWindows_Load(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += (object s, RunWorkerCompletedEventArgs arg) =>
            {
                MessageBox.Show("Entrenamiento completado");
                button3.Enabled = true;
                btPredict.Enabled = true;
                worker.WorkerReportsProgress = false;

                progressBar1.Visible = false;
            };

            worker.ProgressChanged += (s, args) =>
            {
                progressBar1.Value = args.ProgressPercentage;
                var state = (NeuralNetwork.ReportProgressModel)args.UserState;
                tbReport.Text += System.Environment.NewLine +
                                $"Perdida: {state.loss} epoch; {state.epoch}";

            };

            worker.WorkerSupportsCancellation = true;

            openFileWorker = new BackgroundWorker();
            openFileWorker.DoWork += OpenFileWorker_DoWork;
            openFileWorker.RunWorkerCompleted += (ob, args) =>
            {
                dataGridView1.DataSource = dataTable;

                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
                    c.Selected = false;
                }
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;

                progressBar1.Value = 0;
                progressBar1.Visible = false;
            };

            openFileWorker.ProgressChanged += (s, args) =>
            {
                progressBar1.Value = args.ProgressPercentage;
            };

        }



        private void Worker_DoWork(object sender, DoWorkEventArgs e)
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
            nn.LearningRate = double.Parse(tbLearningRate.Text);
            nn.Epoch = int.Parse(tbEpoch.Text);
            nn.BatchSize = int.Parse(tbBatches.Text);
            nn.SetLoss = loss;
            nn.Optiizer = optimizer;
            //try
            //{
            model = nn.Fit(X, Y, ((BackgroundWorker)sender));



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

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            nn = new NeuralNetwork.NeuralNetwork();
            nn.Load(openFileDialog1.FileName);
            predictFields = tbPredictoras.Text.Split(',').ToList();
            targetFields = tbObjetivos.Text.Split(',').ToList();

            init = true;
            button4.Enabled = true;
            btPredict.Enabled = true;
        }

        private void DataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 10;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //pause event
            worker.CancelAsync();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {

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

            hl.ForEach(x => layers.Add(new Layer(int.Parse(x), activationHidden)));

            layers.Add(new Layer(Y.First().Length, activationOutput));

            nn = new NeuralNetwork.NeuralNetwork(layers, leraningRate, epoch, loss, false, batches,
                                       optimizer: optimizer);

            init = true;
            button4.Enabled = true;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Esta accion eliminara los pesos asociados al modelo de RN",
                                        "Esta seguro que desea reiniciar este modelo?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                init = false;
                nn = null;
                progressBar1.Value = 0;
            }
        }

        private void YVsYpredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PredCharForm(Ytest, Ypred).ShowDialog();
        }

        private void YVsYpredDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PredGridForm(Ytest, Ypred).ShowDialog();
        }
    }
}
