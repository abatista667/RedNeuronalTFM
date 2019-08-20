namespace NeuralNetworkGUI
{
    partial class AnomalyDetectorForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btLoadTrained = new System.Windows.Forms.Button();
            this.btLoadAnomalies = new System.Windows.Forms.Button();
            this.btLoadModel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btPredict = new System.Windows.Forms.Button();
            this.btCalc = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(582, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 215);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(582, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // btLoadTrained
            // 
            this.btLoadTrained.Location = new System.Drawing.Point(12, 168);
            this.btLoadTrained.Name = "btLoadTrained";
            this.btLoadTrained.Size = new System.Drawing.Size(135, 23);
            this.btLoadTrained.TabIndex = 3;
            this.btLoadTrained.Text = "Cargar Dataset Normal";
            this.btLoadTrained.UseVisualStyleBackColor = true;
            // 
            // btLoadAnomalies
            // 
            this.btLoadAnomalies.Location = new System.Drawing.Point(153, 168);
            this.btLoadAnomalies.Name = "btLoadAnomalies";
            this.btLoadAnomalies.Size = new System.Drawing.Size(192, 23);
            this.btLoadAnomalies.TabIndex = 4;
            this.btLoadAnomalies.Text = "Cargar Dataset con Anomalias";
            this.btLoadAnomalies.UseVisualStyleBackColor = true;
            // 
            // btLoadModel
            // 
            this.btLoadModel.Location = new System.Drawing.Point(12, 371);
            this.btLoadModel.Name = "btLoadModel";
            this.btLoadModel.Size = new System.Drawing.Size(135, 23);
            this.btLoadModel.TabIndex = 5;
            this.btLoadModel.Text = "Cargar Modelo";
            this.btLoadModel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Establecer Perdida";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 432);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // btPredict
            // 
            this.btPredict.Location = new System.Drawing.Point(220, 430);
            this.btPredict.Name = "btPredict";
            this.btPredict.Size = new System.Drawing.Size(75, 23);
            this.btPredict.TabIndex = 8;
            this.btPredict.Text = "Predecir";
            this.btPredict.UseVisualStyleBackColor = true;
            // 
            // btCalc
            // 
            this.btCalc.Location = new System.Drawing.Point(153, 371);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(135, 23);
            this.btCalc.TabIndex = 9;
            this.btCalc.Text = "Calcular";
            this.btCalc.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(609, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(527, 515);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // AnomalyDetectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 539);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.btPredict);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLoadModel);
            this.Controls.Add(this.btLoadAnomalies);
            this.Controls.Add(this.btLoadTrained);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AnomalyDetectorForm";
            this.Text = "Detector de Anomalias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btLoadTrained;
        private System.Windows.Forms.Button btLoadAnomalies;
        private System.Windows.Forms.Button btLoadModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btPredict;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}