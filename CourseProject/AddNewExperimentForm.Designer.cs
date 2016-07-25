namespace CourseProject
{
    partial class AddNewExperimentForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.experimentsTextBox = new System.Windows.Forms.TextBox();
            this.partitionsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gammaTextBox = new System.Windows.Forms.TextBox();
            this.beginTextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.inverseCheckBox = new System.Windows.Forms.CheckBox();
            this.neymanCheckBox = new System.Windows.Forms.CheckBox();
            this.metropolisCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inverseFunctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neymanChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metropolisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveButton = new System.Windows.Forms.Button();
            this.actualProgressLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inverseFunctionChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neymanChart)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metropolisChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Experiments amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Partitions amount";
            // 
            // experimentsTextBox
            // 
            this.experimentsTextBox.Location = new System.Drawing.Point(132, 15);
            this.experimentsTextBox.Name = "experimentsTextBox";
            this.experimentsTextBox.Size = new System.Drawing.Size(100, 20);
            this.experimentsTextBox.TabIndex = 2;
            this.experimentsTextBox.Text = "10000";
            this.experimentsTextBox.TextChanged += new System.EventHandler(this.ExperimentsTextBox_TextChanged);
            // 
            // partitionsTextBox
            // 
            this.partitionsTextBox.Location = new System.Drawing.Point(132, 39);
            this.partitionsTextBox.Name = "partitionsTextBox";
            this.partitionsTextBox.Size = new System.Drawing.Size(100, 20);
            this.partitionsTextBox.TabIndex = 3;
            this.partitionsTextBox.Text = "100";
            this.partitionsTextBox.TextChanged += new System.EventHandler(this.PartitionsTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scale parameter (γ>0)";
            // 
            // gammaTextBox
            // 
            this.gammaTextBox.Location = new System.Drawing.Point(132, 65);
            this.gammaTextBox.Name = "gammaTextBox";
            this.gammaTextBox.Size = new System.Drawing.Size(100, 20);
            this.gammaTextBox.TabIndex = 5;
            this.gammaTextBox.Text = "1";
            this.gammaTextBox.TextChanged += new System.EventHandler(this.GammaTextBox_TextChanged);
            // 
            // beginTextBox
            // 
            this.beginTextBox.Location = new System.Drawing.Point(132, 98);
            this.beginTextBox.Name = "beginTextBox";
            this.beginTextBox.Size = new System.Drawing.Size(100, 20);
            this.beginTextBox.TabIndex = 6;
            this.beginTextBox.Text = "-5";
            this.beginTextBox.TextChanged += new System.EventHandler(this.BeginTextBox_TextChanged);
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(132, 124);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(100, 20);
            this.endTextBox.TabIndex = 7;
            this.endTextBox.Text = "5";
            this.endTextBox.TextChanged += new System.EventHandler(this.EndTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Interval begin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Interval end";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 229);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(217, 30);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(15, 265);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(217, 30);
            this.pauseButton.TabIndex = 14;
            this.pauseButton.Text = "PAUSE";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(15, 301);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(217, 30);
            this.stopButton.TabIndex = 15;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 416);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(71, 13);
            this.progressLabel.TabIndex = 16;
            this.progressLabel.Text = "Progress (0%)";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(107, 406);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(762, 23);
            this.progressBar.TabIndex = 17;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // inverseCheckBox
            // 
            this.inverseCheckBox.AutoSize = true;
            this.inverseCheckBox.Checked = true;
            this.inverseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inverseCheckBox.Location = new System.Drawing.Point(15, 158);
            this.inverseCheckBox.Name = "inverseCheckBox";
            this.inverseCheckBox.Size = new System.Drawing.Size(140, 17);
            this.inverseCheckBox.TabIndex = 18;
            this.inverseCheckBox.Text = "Inverse function method";
            this.inverseCheckBox.UseVisualStyleBackColor = true;
            // 
            // neymanCheckBox
            // 
            this.neymanCheckBox.AutoSize = true;
            this.neymanCheckBox.Checked = true;
            this.neymanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.neymanCheckBox.Location = new System.Drawing.Point(15, 181);
            this.neymanCheckBox.Name = "neymanCheckBox";
            this.neymanCheckBox.Size = new System.Drawing.Size(110, 17);
            this.neymanCheckBox.TabIndex = 19;
            this.neymanCheckBox.Text = "Neumann method";
            this.neymanCheckBox.UseVisualStyleBackColor = true;
            // 
            // metropolisCheckBox
            // 
            this.metropolisCheckBox.AutoSize = true;
            this.metropolisCheckBox.Checked = true;
            this.metropolisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metropolisCheckBox.Location = new System.Drawing.Point(15, 204);
            this.metropolisCheckBox.Name = "metropolisCheckBox";
            this.metropolisCheckBox.Size = new System.Drawing.Size(112, 17);
            this.metropolisCheckBox.TabIndex = 20;
            this.metropolisCheckBox.Text = "Metropolis method";
            this.metropolisCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(238, 15);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(631, 385);
            this.tabControl.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inverseFunctionChart);
            this.tabPage1.Enabled = false;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(623, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inverse function method";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inverseFunctionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.inverseFunctionChart.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.inverseFunctionChart.Legends.Add(legend1);
            this.inverseFunctionChart.Location = new System.Drawing.Point(-4, 0);
            this.inverseFunctionChart.Name = "inverseFunctionChart";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Analytic method";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Inverse function method";
            this.inverseFunctionChart.Series.Add(series1);
            this.inverseFunctionChart.Series.Add(series2);
            this.inverseFunctionChart.Size = new System.Drawing.Size(631, 363);
            this.inverseFunctionChart.TabIndex = 0;
            this.inverseFunctionChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neymanChart);
            this.tabPage2.Enabled = false;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(623, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Neumann method";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neymanChart
            // 
            chartArea2.Name = "ChartArea1";
            this.neymanChart.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.neymanChart.Legends.Add(legend2);
            this.neymanChart.Location = new System.Drawing.Point(-4, 0);
            this.neymanChart.Name = "neymanChart";
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Analytic method";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Neyman method";
            this.neymanChart.Series.Add(series3);
            this.neymanChart.Series.Add(series4);
            this.neymanChart.Size = new System.Drawing.Size(631, 363);
            this.neymanChart.TabIndex = 0;
            this.neymanChart.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.metropolisChart);
            this.tabPage3.Enabled = false;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(623, 359);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Metropolis method";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // metropolisChart
            // 
            chartArea3.Name = "ChartArea1";
            this.metropolisChart.ChartAreas.Add(chartArea3);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Name = "Legend1";
            this.metropolisChart.Legends.Add(legend3);
            this.metropolisChart.Location = new System.Drawing.Point(-4, 0);
            this.metropolisChart.Name = "metropolisChart";
            series5.BorderWidth = 4;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "Analytic method";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Metropolis method";
            this.metropolisChart.Series.Add(series5);
            this.metropolisChart.Series.Add(series6);
            this.metropolisChart.Size = new System.Drawing.Size(631, 363);
            this.metropolisChart.TabIndex = 0;
            this.metropolisChart.Text = "chart1";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(15, 338);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(217, 30);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // actualProgressLabel
            // 
            this.actualProgressLabel.AutoSize = true;
            this.actualProgressLabel.Location = new System.Drawing.Point(12, 383);
            this.actualProgressLabel.Name = "actualProgressLabel";
            this.actualProgressLabel.Size = new System.Drawing.Size(74, 13);
            this.actualProgressLabel.TabIndex = 23;
            this.actualProgressLabel.Text = "Progress (0/0)";
            // 
            // AddNewExperimentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 438);
            this.Controls.Add(this.actualProgressLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.metropolisCheckBox);
            this.Controls.Add(this.neymanCheckBox);
            this.Controls.Add(this.inverseCheckBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endTextBox);
            this.Controls.Add(this.beginTextBox);
            this.Controls.Add(this.gammaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.partitionsTextBox);
            this.Controls.Add(this.experimentsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewExperimentForm";
            this.Text = "New experiment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewExperimentForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inverseFunctionChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neymanChart)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metropolisChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox experimentsTextBox;
        private System.Windows.Forms.TextBox partitionsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gammaTextBox;
        private System.Windows.Forms.TextBox beginTextBox;
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox inverseCheckBox;
        private System.Windows.Forms.CheckBox neymanCheckBox;
        private System.Windows.Forms.CheckBox metropolisCheckBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart inverseFunctionChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart neymanChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart metropolisChart;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label actualProgressLabel;
    }
}

