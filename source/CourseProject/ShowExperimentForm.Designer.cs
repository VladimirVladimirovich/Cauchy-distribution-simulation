namespace CourseProject
{
    partial class ShowExperimentForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inverseFunctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neymanChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metropolisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataInputLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inverseFunctionChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neymanChart)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metropolisChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(159, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(599, 353);
            this.tabControl.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inverseFunctionChart);
            this.tabPage1.Enabled = false;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(591, 327);
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
            this.inverseFunctionChart.Size = new System.Drawing.Size(599, 331);
            this.inverseFunctionChart.TabIndex = 0;
            this.inverseFunctionChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neymanChart);
            this.tabPage2.Enabled = false;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(591, 327);
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
            this.neymanChart.Size = new System.Drawing.Size(599, 331);
            this.neymanChart.TabIndex = 0;
            this.neymanChart.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.metropolisChart);
            this.tabPage3.Enabled = false;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(591, 327);
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
            this.metropolisChart.Size = new System.Drawing.Size(599, 331);
            this.metropolisChart.TabIndex = 0;
            this.metropolisChart.Text = "chart1";
            // 
            // dataInputLabel
            // 
            this.dataInputLabel.AutoSize = true;
            this.dataInputLabel.Location = new System.Drawing.Point(12, 12);
            this.dataInputLabel.Name = "dataInputLabel";
            this.dataInputLabel.Size = new System.Drawing.Size(35, 13);
            this.dataInputLabel.TabIndex = 23;
            this.dataInputLabel.Text = "label1";
            // 
            // ShowExperimentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 371);
            this.Controls.Add(this.dataInputLabel);
            this.Controls.Add(this.tabControl);
            this.Name = "ShowExperimentForm";
            this.Text = "Experiment results";
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

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart inverseFunctionChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart neymanChart;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart metropolisChart;
        private System.Windows.Forms.Label dataInputLabel;

    }
}