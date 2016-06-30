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
        Experiment experiment;

        public ShowExperimentForm(Experiment experiment)
        {
            InitializeComponent();
            this.experiment = new Experiment(experiment);
            addDataInput();
            drawChart();
        }

        private void addDataInput() 
        {
            String text = "Experiments amount: " + experiment.dataInput.actualExperimentsAmount +
                "\nPartitions amount: " + experiment.dataInput.partitionsAmount +
                "\nScale parameter (γ>0): " + experiment.dataInput.gamma +
                "\nInterval begin: " + experiment.dataInput.intervalBegin +
                "\nInterval end: " + experiment.dataInput.intervalEnd +
                "\n\n" + (experiment.dataInput.isInverseFunctionChecked ? "Inverse function method" : "") +
                (experiment.dataInput.isNeymanChecked ? "\nNeumann method" : "") +
                (experiment.dataInput.isMetropolisChecked ? "\nMetropolis method" : "");

            dataInputLabel.Text = text;
        }

        private void drawChart()
        {
            tabControl.TabPages[0].Enabled = false;
            tabControl.TabPages[1].Enabled = false;
            tabControl.TabPages[2].Enabled = false;

            inverseFunctionChart.Series[0].Points.Clear();
            inverseFunctionChart.Series[1].Points.Clear();

            neymanChart.Series[0].Points.Clear();
            neymanChart.Series[0].Points.Clear();

            metropolisChart.Series[0].Points.Clear();
            metropolisChart.Series[0].Points.Clear();

            if (experiment.dataInput.isInverseFunctionChecked)
            {
                tabControl.TabPages[0].Enabled = true;

                inverseFunctionChart.Series[0].Points.Clear();
                inverseFunctionChart.Series[1].Points.Clear();

                inverseFunctionChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                inverseFunctionChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                inverseFunctionChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                inverseFunctionChart.Series[1].Points.DataBindXY(experiment.inverseFunctionMethodObj.getIntervalsList(), experiment.inverseFunctionMethodObj.getResultList());
            }

            if (experiment.dataInput.isNeymanChecked)
            {
                tabControl.TabPages[1].Enabled = true;

                neymanChart.Series[0].Points.Clear();
                neymanChart.Series[1].Points.Clear();

                neymanChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                neymanChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                neymanChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                neymanChart.Series[1].Points.DataBindXY(experiment.neymanMethodObj.getIntervalsList(), experiment.neymanMethodObj.getResultList());
            }

            if (experiment.dataInput.isMetropolisChecked)
            {
                tabControl.TabPages[2].Enabled = true;

                metropolisChart.Series[0].Points.Clear();
                metropolisChart.Series[1].Points.Clear();

                metropolisChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                metropolisChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                metropolisChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                metropolisChart.Series[1].Points.DataBindXY(experiment.metropolisMethodObj.getIntervalsList(), experiment.metropolisMethodObj.getResultList());
            }
        }
    }
}
