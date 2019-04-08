namespace NeuralNetworkClassification
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
			this.tbTest = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbLearningRate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbBatches = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbEpoch = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tbObjetivos = new System.Windows.Forms.TextBox();
			this.tbPredictoras = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cargarDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tbHidden = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbTest
			// 
			this.tbTest.Location = new System.Drawing.Point(534, 424);
			this.tbTest.Name = "tbTest";
			this.tbTest.Size = new System.Drawing.Size(57, 20);
			this.tbTest.TabIndex = 32;
			this.tbTest.Text = "1";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(425, 431);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 13);
			this.label6.TabIndex = 31;
			this.label6.Text = "Registros de Prueba";
			// 
			// tbLearningRate
			// 
			this.tbLearningRate.Location = new System.Drawing.Point(168, 476);
			this.tbLearningRate.Name = "tbLearningRate";
			this.tbLearningRate.Size = new System.Drawing.Size(229, 20);
			this.tbLearningRate.TabIndex = 30;
			this.tbLearningRate.Text = "0.000000001";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(53, 483);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 13);
			this.label5.TabIndex = 29;
			this.label5.Text = "Tasa de Aprendisaje";
			// 
			// tbBatches
			// 
			this.tbBatches.Location = new System.Drawing.Point(168, 450);
			this.tbBatches.Name = "tbBatches";
			this.tbBatches.Size = new System.Drawing.Size(229, 20);
			this.tbBatches.TabIndex = 28;
			this.tbBatches.Text = "1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(53, 457);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 27;
			this.label4.Text = "Batches";
			// 
			// tbEpoch
			// 
			this.tbEpoch.Location = new System.Drawing.Point(168, 424);
			this.tbEpoch.Name = "tbEpoch";
			this.tbEpoch.Size = new System.Drawing.Size(229, 20);
			this.tbEpoch.TabIndex = 26;
			this.tbEpoch.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(53, 431);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "Epoch";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(673, 303);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 54);
			this.button3.TabIndex = 24;
			this.button3.Text = "Entrenar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(403, 335);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 23;
			this.button2.Text = "Seleccionar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(403, 303);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 22;
			this.button1.Text = "Seleccionar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// tbObjetivos
			// 
			this.tbObjetivos.Location = new System.Drawing.Point(168, 337);
			this.tbObjetivos.Name = "tbObjetivos";
			this.tbObjetivos.Size = new System.Drawing.Size(229, 20);
			this.tbObjetivos.TabIndex = 21;
			// 
			// tbPredictoras
			// 
			this.tbPredictoras.Location = new System.Drawing.Point(168, 305);
			this.tbPredictoras.Name = "tbPredictoras";
			this.tbPredictoras.Size = new System.Drawing.Size(229, 20);
			this.tbPredictoras.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(53, 340);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Columnas Objetivo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(53, 308);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Columnas Predictoras";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(23, 39);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(765, 249);
			this.dataGridView1.TabIndex = 17;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 33;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarDatasetToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
			// cargarDatasetToolStripMenuItem
			// 
			this.cargarDatasetToolStripMenuItem.Name = "cargarDatasetToolStripMenuItem";
			this.cargarDatasetToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.cargarDatasetToolStripMenuItem.Text = "Cargar Dataset";
			this.cargarDatasetToolStripMenuItem.Click += new System.EventHandler(this.CargarDatasetToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
			// 
			// tbHidden
			// 
			this.tbHidden.Location = new System.Drawing.Point(168, 363);
			this.tbHidden.Name = "tbHidden";
			this.tbHidden.Size = new System.Drawing.Size(229, 20);
			this.tbHidden.TabIndex = 35;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(53, 366);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 34;
			this.label7.Text = "Nodos Ocultos";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(515, 324);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 36;
			this.label8.Text = "Perdida";
			// 
			// MainWindows
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 514);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbHidden);
			this.Controls.Add(this.label7);
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
			this.Text = "Multilayer Perceptron Clasificacion";
			this.Load += new System.EventHandler(this.MainWindows_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLearningRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEpoch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbObjetivos;
        private System.Windows.Forms.TextBox tbPredictoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarDatasetToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbHidden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

