namespace NeuralNetworkGUI
{
    partial class ImageClassifier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lbperdida = new System.Windows.Forms.Label();
            this.lbepoch = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHeigth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbHidden = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEpoch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLearningRate = new System.Windows.Forms.TextBox();
            this.cbOptimizer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckReiniciar = new System.Windows.Forms.CheckBox();
            this.tbBatches = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCheckpoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.lbtiempo = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(193, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(335, 20);
            this.tbPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ruta Consjunto de Entrenamiento:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(615, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Entrenar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(193, 157);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(595, 311);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(615, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Evaluar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(335, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ruta Conjunto de Prueba:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(534, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Cargar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbperdida
            // 
            this.lbperdida.AutoSize = true;
            this.lbperdida.Location = new System.Drawing.Point(12, 492);
            this.lbperdida.Name = "lbperdida";
            this.lbperdida.Size = new System.Drawing.Size(43, 13);
            this.lbperdida.TabIndex = 13;
            this.lbperdida.Text = "Perdida";
            // 
            // lbepoch
            // 
            this.lbepoch.AutoSize = true;
            this.lbepoch.Location = new System.Drawing.Point(114, 492);
            this.lbepoch.Name = "lbepoch";
            this.lbepoch.Size = new System.Drawing.Size(38, 13);
            this.lbepoch.TabIndex = 14;
            this.lbepoch.Text = "Epoch";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(193, 482);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(595, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(534, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Seleccionar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Redimensionar a:";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(193, 65);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(100, 20);
            this.tbWidth.TabIndex = 18;
            this.tbWidth.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "X";
            // 
            // tbHeigth
            // 
            this.tbHeigth.Location = new System.Drawing.Point(319, 65);
            this.tbHeigth.Name = "tbHeigth";
            this.tbHeigth.Size = new System.Drawing.Size(100, 20);
            this.tbHeigth.TabIndex = 20;
            this.tbHeigth.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Nodos Capas internas";
            // 
            // tbHidden
            // 
            this.tbHidden.Location = new System.Drawing.Point(15, 174);
            this.tbHidden.Name = "tbHidden";
            this.tbHidden.Size = new System.Drawing.Size(149, 20);
            this.tbHidden.TabIndex = 22;
            this.tbHidden.Text = "64";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Epochs:";
            // 
            // tbEpoch
            // 
            this.tbEpoch.Location = new System.Drawing.Point(15, 213);
            this.tbEpoch.Name = "tbEpoch";
            this.tbEpoch.Size = new System.Drawing.Size(149, 20);
            this.tbEpoch.TabIndex = 24;
            this.tbEpoch.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tasa de aprendizaje";
            // 
            // tbLearningRate
            // 
            this.tbLearningRate.Location = new System.Drawing.Point(15, 293);
            this.tbLearningRate.Name = "tbLearningRate";
            this.tbLearningRate.Size = new System.Drawing.Size(149, 20);
            this.tbLearningRate.TabIndex = 26;
            this.tbLearningRate.Text = "0.003";
            // 
            // cbOptimizer
            // 
            this.cbOptimizer.FormattingEnabled = true;
            this.cbOptimizer.Items.AddRange(new object[] {
            "ADAM",
            "SGD"});
            this.cbOptimizer.Location = new System.Drawing.Point(15, 332);
            this.cbOptimizer.Name = "cbOptimizer";
            this.cbOptimizer.Size = new System.Drawing.Size(146, 21);
            this.cbOptimizer.TabIndex = 29;
            this.cbOptimizer.Text = "ADAM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Optimizador";
            // 
            // ckReiniciar
            // 
            this.ckReiniciar.AutoSize = true;
            this.ckReiniciar.Checked = true;
            this.ckReiniciar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckReiniciar.Location = new System.Drawing.Point(15, 359);
            this.ckReiniciar.Name = "ckReiniciar";
            this.ckReiniciar.Size = new System.Drawing.Size(85, 17);
            this.ckReiniciar.TabIndex = 32;
            this.ckReiniciar.Text = "Reiniciar red";
            this.ckReiniciar.UseVisualStyleBackColor = true;
            // 
            // tbBatches
            // 
            this.tbBatches.Location = new System.Drawing.Point(15, 254);
            this.tbBatches.Name = "tbBatches";
            this.tbBatches.Size = new System.Drawing.Size(149, 20);
            this.tbBatches.TabIndex = 34;
            this.tbBatches.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Tam. Batch";
            // 
            // tbCheckpoint
            // 
            this.tbCheckpoint.Location = new System.Drawing.Point(193, 91);
            this.tbCheckpoint.Name = "tbCheckpoint";
            this.tbCheckpoint.ReadOnly = true;
            this.tbCheckpoint.Size = new System.Drawing.Size(335, 20);
            this.tbCheckpoint.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Guardar avances";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Cargar Modelo";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(335, 20);
            this.textBox2.TabIndex = 38;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(534, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 23);
            this.button6.TabIndex = 37;
            this.button6.Text = "Cargar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(696, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 40;
            this.button7.Text = "Parar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lbtiempo
            // 
            this.lbtiempo.AutoSize = true;
            this.lbtiempo.Location = new System.Drawing.Point(693, 94);
            this.lbtiempo.Name = "lbtiempo";
            this.lbtiempo.Size = new System.Drawing.Size(45, 13);
            this.lbtiempo.TabIndex = 41;
            this.lbtiempo.Text = "Tiempo:";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(648, 117);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 23);
            this.button8.TabIndex = 42;
            this.button8.Text = "Limpiar Grafico";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // ImageClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.lbtiempo);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCheckpoint);
            this.Controls.Add(this.tbBatches);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ckReiniciar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbOptimizer);
            this.Controls.Add(this.tbLearningRate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbEpoch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbHidden);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbHeigth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbepoch);
            this.Controls.Add(this.lbperdida);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label1);
            this.Name = "ImageClassifier";
            this.Text = "Entrenar Clasificador de imagenes";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbperdida;
        private System.Windows.Forms.Label lbepoch;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHeigth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbHidden;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEpoch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLearningRate;
        private System.Windows.Forms.ComboBox cbOptimizer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckReiniciar;
        private System.Windows.Forms.TextBox tbBatches;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCheckpoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lbtiempo;
        private System.Windows.Forms.Button button8;
    }
}