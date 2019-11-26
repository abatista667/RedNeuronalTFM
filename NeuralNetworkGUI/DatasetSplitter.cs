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
    public partial class DatasetSplitter : Form
    {
        string[][] data;
        string[] header;
        FolderBrowserDialog fb;
        private static Random rng = new Random();
        public DatasetSplitter()
        {
            InitializeComponent();
            fb = new FolderBrowserDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (fb.ShowDialog() == DialogResult.OK)
            {
                int percentage = int.Parse(tbPercentage.Text);
                int test = Convert.ToInt32(Math.Ceiling(percentage / 100f * data.Length));
                Split(test, fb.SelectedPath);
            };
        }

        private void Split(int testCount, string selectedPath)
        {
            List<int> randoms = GenerateRandom(data.Length - 1);
            int counter = 1;
            var train = new List<string[]>() { header };
            var test = new List<string[]>() { header };


            foreach (var i in randoms)
            {
                if (counter > testCount)
                {
                    train.Add(data[i]);
                }
                else
                {
                    test.Add(data[i]);
                }
                counter++;
            }
            Save(selectedPath + "\\_train.csv", train.ToArray());
            Save(selectedPath + "\\_test.csv", test.ToArray());
            MessageBox.Show("datasets separado correctamente");
        }

        void Save(string path, string[][] data)
        {
            var lines = new List<string>();
            foreach (var item in data)
            {
                lines.Add(string.Join(",", item));
            }
            File.WriteAllLines(path, lines);
        }

        private List<int> GenerateRandom(int v)
        {
            var list = new List<int>();
            for (int i = 0; i <= v; i++)
            {
                list.Add(i);
            }
            ReorderList(list);
            return list;
        }

        private void ReorderList(List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            tbPath.Text = openFileDialog1.FileName;
            var tempData = new List<string[]>();
            foreach (var f in File.ReadLines(openFileDialog1.FileName).Skip(1))
            {
                var row = f.Split(',');
                tempData.Add(row);
            }
            data = tempData.ToArray();
            header = File.ReadLines(openFileDialog1.FileName).Take(1).First().Split(',');
        }
    }
}
