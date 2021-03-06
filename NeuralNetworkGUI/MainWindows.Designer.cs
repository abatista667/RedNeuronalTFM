﻿using System;

namespace NeuralNetworkGUI
{
    partial class MainWindows
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarDataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perdidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yVsYpredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yVsYpredDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prediccionAnomaliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separarDatasetEnClasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorDeAnomaliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separarDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entrenarModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predecirClasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OFDDataSet = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPredictoras = new System.Windows.Forms.TextBox();
            this.tbObjetivos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEpoch = new System.Windows.Forms.TextBox();
            this.tbBatches = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLearningRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHidden = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btPredict = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.cbActivation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbActivationHidden = new System.Windows.Forms.ComboBox();
            this.cbLoss = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbOptimizer = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.estadisticasToolStripMenuItem,
            this.prediccionAnomaliasToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.imagenesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarDataSetToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.cerrarToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // cargarDataSetToolStripMenuItem
            // 
            this.cargarDataSetToolStripMenuItem.Name = "cargarDataSetToolStripMenuItem";
            this.cargarDataSetToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cargarDataSetToolStripMenuItem.Text = "Cargar DataSet";
            this.cargarDataSetToolStripMenuItem.Click += new System.EventHandler(this.cargarDataSetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem2.Text = "Reiniciar Modelo";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem5.Text = "Reiniciar Todo";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem3.Text = "Guardar modelo";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem4.Text = "Cargar Modelo";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perdidaToolStripMenuItem,
            this.yVsYpredToolStripMenuItem,
            this.yVsYpredDetalleToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // perdidaToolStripMenuItem
            // 
            this.perdidaToolStripMenuItem.Name = "perdidaToolStripMenuItem";
            this.perdidaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.perdidaToolStripMenuItem.Text = "Perdida";
            this.perdidaToolStripMenuItem.Click += new System.EventHandler(this.perdidaToolStripMenuItem_Click);
            // 
            // yVsYpredToolStripMenuItem
            // 
            this.yVsYpredToolStripMenuItem.Name = "yVsYpredToolStripMenuItem";
            this.yVsYpredToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yVsYpredToolStripMenuItem.Text = "Y vs Ypred";
            this.yVsYpredToolStripMenuItem.Click += new System.EventHandler(this.YVsYpredToolStripMenuItem_Click);
            // 
            // yVsYpredDetalleToolStripMenuItem
            // 
            this.yVsYpredDetalleToolStripMenuItem.Name = "yVsYpredDetalleToolStripMenuItem";
            this.yVsYpredDetalleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yVsYpredDetalleToolStripMenuItem.Text = "Y vs Ypred detalle";
            this.yVsYpredDetalleToolStripMenuItem.Click += new System.EventHandler(this.YVsYpredDetalleToolStripMenuItem_Click);
            // 
            // prediccionAnomaliasToolStripMenuItem
            // 
            this.prediccionAnomaliasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separarDatasetEnClasesToolStripMenuItem,
            this.detectorDeAnomaliasToolStripMenuItem});
            this.prediccionAnomaliasToolStripMenuItem.Name = "prediccionAnomaliasToolStripMenuItem";
            this.prediccionAnomaliasToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.prediccionAnomaliasToolStripMenuItem.Text = "Prediccion Anomalias";
            // 
            // separarDatasetEnClasesToolStripMenuItem
            // 
            this.separarDatasetEnClasesToolStripMenuItem.Name = "separarDatasetEnClasesToolStripMenuItem";
            this.separarDatasetEnClasesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.separarDatasetEnClasesToolStripMenuItem.Text = "Separar Dataset en Clases";
            this.separarDatasetEnClasesToolStripMenuItem.Click += new System.EventHandler(this.SepararDatasetEnClasesToolStripMenuItem_Click);
            // 
            // detectorDeAnomaliasToolStripMenuItem
            // 
            this.detectorDeAnomaliasToolStripMenuItem.Name = "detectorDeAnomaliasToolStripMenuItem";
            this.detectorDeAnomaliasToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.detectorDeAnomaliasToolStripMenuItem.Text = "Detector de Anomalias";
            this.detectorDeAnomaliasToolStripMenuItem.Click += new System.EventHandler(this.DetectorDeAnomaliasToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separarDatasetToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // separarDatasetToolStripMenuItem
            // 
            this.separarDatasetToolStripMenuItem.Name = "separarDatasetToolStripMenuItem";
            this.separarDatasetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.separarDatasetToolStripMenuItem.Text = "Separar Dataset %";
            this.separarDatasetToolStripMenuItem.Click += new System.EventHandler(this.SepararDatasetToolStripMenuItem_Click);
            // 
            // imagenesToolStripMenuItem
            // 
            this.imagenesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entrenarModeloToolStripMenuItem,
            this.predecirClasesToolStripMenuItem});
            this.imagenesToolStripMenuItem.Name = "imagenesToolStripMenuItem";
            this.imagenesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.imagenesToolStripMenuItem.Text = "Imagenes";
            // 
            // entrenarModeloToolStripMenuItem
            // 
            this.entrenarModeloToolStripMenuItem.Name = "entrenarModeloToolStripMenuItem";
            this.entrenarModeloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.entrenarModeloToolStripMenuItem.Text = "Entrenar Modelo";
            this.entrenarModeloToolStripMenuItem.Click += new System.EventHandler(this.entrenarModeloToolStripMenuItem_Click);
            // 
            // predecirClasesToolStripMenuItem
            // 
            this.predecirClasesToolStripMenuItem.Name = "predecirClasesToolStripMenuItem";
            this.predecirClasesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.predecirClasesToolStripMenuItem.Text = "Predecir Clases";
            this.predecirClasesToolStripMenuItem.Click += new System.EventHandler(this.predecirClasesToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(695, 278);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView1_ColumnAdded);
            // 
            // OFDDataSet
            // 
            this.OFDDataSet.FileOk += new System.ComponentModel.CancelEventHandler(this.OFDDataSet_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columnas Predictoras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columnas Objetivo";
            // 
            // tbPredictoras
            // 
            this.tbPredictoras.Location = new System.Drawing.Point(127, 313);
            this.tbPredictoras.Name = "tbPredictoras";
            this.tbPredictoras.Size = new System.Drawing.Size(229, 20);
            this.tbPredictoras.TabIndex = 4;
            // 
            // tbObjetivos
            // 
            this.tbObjetivos.Location = new System.Drawing.Point(127, 345);
            this.tbObjetivos.Name = "tbObjetivos";
            this.tbObjetivos.Size = new System.Drawing.Size(229, 20);
            this.tbObjetivos.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(551, 311);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 54);
            this.button3.TabIndex = 8;
            this.button3.Text = "Entrenar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Epoch";
            // 
            // tbEpoch
            // 
            this.tbEpoch.Location = new System.Drawing.Point(127, 396);
            this.tbEpoch.Name = "tbEpoch";
            this.tbEpoch.Size = new System.Drawing.Size(229, 20);
            this.tbEpoch.TabIndex = 10;
            this.tbEpoch.Text = "1";
            // 
            // tbBatches
            // 
            this.tbBatches.Location = new System.Drawing.Point(127, 422);
            this.tbBatches.Name = "tbBatches";
            this.tbBatches.Size = new System.Drawing.Size(229, 20);
            this.tbBatches.TabIndex = 12;
            this.tbBatches.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Batches";
            // 
            // tbLearningRate
            // 
            this.tbLearningRate.Location = new System.Drawing.Point(127, 448);
            this.tbLearningRate.Name = "tbLearningRate";
            this.tbLearningRate.Size = new System.Drawing.Size(229, 20);
            this.tbLearningRate.TabIndex = 14;
            this.tbLearningRate.Text = "0.000000001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tasa de Aprendisaje";
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(493, 388);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(57, 20);
            this.tbTest.TabIndex = 16;
            this.tbTest.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Registros de Prueba";
            // 
            // tbHidden
            // 
            this.tbHidden.Location = new System.Drawing.Point(127, 371);
            this.tbHidden.Name = "tbHidden";
            this.tbHidden.Size = new System.Drawing.Size(229, 20);
            this.tbHidden.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Nodos ocultos";
            // 
            // btPredict
            // 
            this.btPredict.Enabled = false;
            this.btPredict.Location = new System.Drawing.Point(632, 371);
            this.btPredict.Name = "btPredict";
            this.btPredict.Size = new System.Drawing.Size(75, 54);
            this.btPredict.TabIndex = 20;
            this.btPredict.Text = "Predecir";
            this.btPredict.UseVisualStyleBackColor = true;
            this.btPredict.Click += new System.EventHandler(this.BtPredict_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 487);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Activacion";
            // 
            // cbActivation
            // 
            this.cbActivation.FormattingEnabled = true;
            this.cbActivation.Items.AddRange(new object[] {
            "Ninguno",
            "Sigmoide",
            "Relu",
            "Tanh",
            "Softmax"});
            this.cbActivation.Location = new System.Drawing.Point(127, 484);
            this.cbActivation.Name = "cbActivation";
            this.cbActivation.Size = new System.Drawing.Size(229, 21);
            this.cbActivation.TabIndex = 22;
            this.cbActivation.Text = "Ninguno";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Act Capa Ocultas";
            // 
            // cbActivationHidden
            // 
            this.cbActivationHidden.FormattingEnabled = true;
            this.cbActivationHidden.Items.AddRange(new object[] {
            "Ninguno",
            "Sigmoide",
            "Relu",
            "Tanh",
            "Softmax"});
            this.cbActivationHidden.Location = new System.Drawing.Point(127, 515);
            this.cbActivationHidden.Name = "cbActivationHidden";
            this.cbActivationHidden.Size = new System.Drawing.Size(229, 21);
            this.cbActivationHidden.TabIndex = 24;
            this.cbActivationHidden.Text = "Ninguno";
            // 
            // cbLoss
            // 
            this.cbLoss.FormattingEnabled = true;
            this.cbLoss.Items.AddRange(new object[] {
            "MSE",
            "MAE",
            "MSLE",
            "BinaryCrossEntropy",
            "CategoricalCrossEntropy"});
            this.cbLoss.Location = new System.Drawing.Point(127, 542);
            this.cbLoss.Name = "cbLoss";
            this.cbLoss.Size = new System.Drawing.Size(229, 21);
            this.cbLoss.TabIndex = 26;
            this.cbLoss.Text = "MSE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 545);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Funcion Perdida";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // cbOptimizer
            // 
            this.cbOptimizer.FormattingEnabled = true;
            this.cbOptimizer.Items.AddRange(new object[] {
            "ADAM",
            "SGD"});
            this.cbOptimizer.Location = new System.Drawing.Point(127, 571);
            this.cbOptimizer.Name = "cbOptimizer";
            this.cbOptimizer.Size = new System.Drawing.Size(229, 21);
            this.cbOptimizer.TabIndex = 28;
            this.cbOptimizer.Text = "ADAM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 574);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Optimizador";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 189);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(692, 32);
            this.progressBar1.TabIndex = 29;
            this.progressBar1.Visible = false;
            // 
            // tbReport
            // 
            this.tbReport.Location = new System.Drawing.Point(387, 448);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(266, 110);
            this.tbReport.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(632, 311);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 54);
            this.button4.TabIndex = 31;
            this.button4.Text = "Pausar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(578, 564);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 32;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 604);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cbOptimizer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbLoss);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbActivationHidden);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbActivation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btPredict);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbHidden);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLearningRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbBatches);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEpoch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbObjetivos);
            this.Controls.Add(this.tbPredictoras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindows";
            this.Text = "Perceptron Multicapa";
            this.Load += new System.EventHandler(this.MainWindows_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cargarDataSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.OpenFileDialog OFDDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPredictoras;
        private System.Windows.Forms.TextBox tbObjetivos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perdidaToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEpoch;
        private System.Windows.Forms.TextBox tbBatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLearningRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem yVsYpredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yVsYpredDetalleToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHidden;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btPredict;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbActivation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbActivationHidden;
        private System.Windows.Forms.ComboBox cbLoss;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbOptimizer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem prediccionAnomaliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separarDatasetEnClasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectorDeAnomaliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separarDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entrenarModeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predecirClasesToolStripMenuItem;
    }
}

