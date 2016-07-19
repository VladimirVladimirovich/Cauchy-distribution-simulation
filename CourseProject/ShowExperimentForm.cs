using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class ShowExperimentForm : Form
    {
        #region Private fields
        private Experiment experiment; 
        #endregion

        #region Private constant fields
        private const string dataInputLabelString = "Experiments amount: {0}\nPartitions amount: {1}\nScale parameter (γ>0): {2}\nInterval begin: {3}\nInterval end: {4}\n\n{5}{6}{7}";  
        #endregion

        #region Constructor
        public ShowExperimentForm(Experiment experiment)
        {
            InitializeComponent();
            this.experiment = new Experiment(experiment);
            AddDataInput();
            DrawChart();
        } 
        #endregion

        #region Private methods
        private void AddDataInput()
        {
            object [] parameters = { this.experiment.DataInput.ActualExperimentsAmount,
                                   this.experiment.DataInput.PartitionsAmount,
                                   this.experiment.DataInput.Gamma,
                                   this.experiment.DataInput.IntervalBegin,
                                   this.experiment.DataInput.IntervalEnd,
                                   (experiment.DataInput.IsInverseFunctionChecked ? "Inverse function method" : ""),
                                   (experiment.DataInput.IsNeymanChecked ? "\nNeumann method" : ""),
                                   (experiment.DataInput.IsMetropolisChecked ? "\nMetropolis method" : "") };

            String text = String.Format(dataInputLabelString, parameters);

            dataInputLabel.Text = text;
        }

        private void DrawChart()
        {
            this.tabControl.TabPages[0].Enabled = false;
            this.tabControl.TabPages[1].Enabled = false;
            this.tabControl.TabPages[2].Enabled = false;

            this.inverseFunctionChart.Series[0].Points.Clear();
            this.inverseFunctionChart.Series[1].Points.Clear();

            this.neymanChart.Series[0].Points.Clear();
            this.neymanChart.Series[0].Points.Clear();

            this.metropolisChart.Series[0].Points.Clear();
            this.metropolisChart.Series[0].Points.Clear();

            if (this.experiment.DataInput.IsInverseFunctionChecked)
            {
                this.tabControl.TabPages[0].Enabled = true;

                this.inverseFunctionChart.Series[0].Points.Clear();
                this.inverseFunctionChart.Series[1].Points.Clear();

                this.inverseFunctionChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.inverseFunctionChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.inverseFunctionChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.inverseFunctionChart.Series[1].Points.DataBindXY(this.experiment.InverseFunctionMethodObj.GetIntervalsList(), this.experiment.InverseFunctionMethodObj.GetResultList());
            }

            if (this.experiment.DataInput.IsNeymanChecked)
            {
                this.tabControl.TabPages[1].Enabled = true;

                this.neymanChart.Series[0].Points.Clear();
                this.neymanChart.Series[1].Points.Clear();

                this.neymanChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.neymanChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.neymanChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.neymanChart.Series[1].Points.DataBindXY(this.experiment.NeymanMethodObj.GetIntervalsList(), this.experiment.NeymanMethodObj.GetResultList());
            }

            if (this.experiment.DataInput.IsMetropolisChecked)
            {
                this.tabControl.TabPages[2].Enabled = true;

                this.metropolisChart.Series[0].Points.Clear();
                this.metropolisChart.Series[1].Points.Clear();

                this.metropolisChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.metropolisChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.metropolisChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.metropolisChart.Series[1].Points.DataBindXY(this.experiment.MetropolisMethodObj.GetIntervalsList(), this.experiment.MetropolisMethodObj.GetResultList());
            }
        } 
        #endregion
    }
}
