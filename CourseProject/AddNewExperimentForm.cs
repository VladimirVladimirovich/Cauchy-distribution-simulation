using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CourseProject
{
    public partial class AddNewExperimentForm : Form
    {
        #region Private fields;
        private MainForm mainForm;
        private DataInput dataInput;
        private AnalyticMethod analyticObj;
        private InverseFunctionMethod inverseMethodObj;
        private NeymanMethod neymanMethodObj;
        private MetropolisMethod metropolisMethodObj;
        private Experiment experiment;
        private int actualExperimentAmount;
        private bool pause;
        private bool isSaved; 
        #endregion

        #region Private static fields
        private static Random random;
        #endregion

        #region Constructors
        public AddNewExperimentForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        } 
        #endregion

        #region Private methods
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (this.CheckInputs())
                this.GetInputs();
            else
                return;

            AddNewExperimentForm.random = new Random();
            this.analyticObj = new AnalyticMethod(this.dataInput.Gamma, this.dataInput.IntervalBegin, this.dataInput.IntervalEnd, this.dataInput.X0);
            this.inverseMethodObj = new InverseFunctionMethod(this.dataInput.ExperimentsAmount, this.dataInput.PartitionsAmount, this.dataInput.Gamma, this.dataInput.IntervalBegin, this.dataInput.IntervalEnd, this.dataInput.X0);
            this.neymanMethodObj = new NeymanMethod(this.dataInput.ExperimentsAmount, this.dataInput.PartitionsAmount, this.dataInput.Gamma, this.dataInput.IntervalBegin, this.dataInput.IntervalEnd, this.dataInput.X0);
            this.metropolisMethodObj = new MetropolisMethod(this.dataInput.ExperimentsAmount, this.dataInput.PartitionsAmount, this.dataInput.Gamma, this.dataInput.IntervalBegin, this.dataInput.IntervalEnd, this.dataInput.X0);
            this.experiment = new Experiment(this.dataInput, this.analyticObj, this.inverseMethodObj, this.neymanMethodObj, this.metropolisMethodObj);

            this.actualExperimentAmount = 0;
            this.pause = false;
            this.isSaved = false;

            this.SetButtonsEnable(true);
            this.startButton.Enabled = false;
            this.saveButton.Enabled = false;

            this.backgroundWorker.RunWorkerAsync();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (!this.backgroundWorker.IsBusy)
                return;

            if (!this.pause)
            {
                this.pause = true;
                this.pauseButton.Text = "CONTINUE";
            }
            else
            {
                this.pause = false;
                this.pauseButton.Text = "PAUSE";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.IsBusy || this.pause)
            {
                this.backgroundWorker.CancelAsync();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.SaveExperimentToDB();
        }

        private void SetButtonsEnable(bool status)
        {
            this.stopButton.Enabled = status;
            this.pauseButton.Enabled = status;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            double step = this.dataInput.ExperimentsAmount / 100;

            for (int i = 0; i < this.dataInput.ExperimentsAmount; i++)
            {
                if (this.backgroundWorker.CancellationPending)
                    break;

                if (this.inverseCheckBox.Checked)
                    this.experiment.ExecuteInverseMethod(AddNewExperimentForm.random);
                if (this.neymanCheckBox.Checked)
                    this.experiment.ExecuteNeymanMethod(i, AddNewExperimentForm.random);
                if (this.metropolisCheckBox.Checked)
                    this.experiment.ExecuteMetropolisMethod(AddNewExperimentForm.random);

                if (i % step == 0)
                    ((BackgroundWorker)sender).ReportProgress((i * 100) / this.experiment.DataInput.ExperimentsAmount, this.actualExperimentAmount);

                this.actualExperimentAmount++;

                if (this.pause)
                {
                    ((BackgroundWorker)sender).ReportProgress((i * 100) / this.experiment.DataInput.ExperimentsAmount, this.actualExperimentAmount);

                    while (this.pause)
                        if (this.backgroundWorker.CancellationPending)
                        {
                            this.pause = false;
                            return;
                        }
                }
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressLabel.Text = "Progress (" + e.ProgressPercentage.ToString() + "%)";
            this.progressBar.Value = e.ProgressPercentage;
            this.actualProgressLabel.Text = "Progress (" + (int)e.UserState + "/" + this.dataInput.ExperimentsAmount + ")";
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //e.Result
            //e.Cancelled
            //e.Error
            this.experiment.DataInput.ActualExperimentsAmount = this.actualExperimentAmount;
            this.experiment.FillIntervalsList();
            this.DrawChart();

            this.actualProgressLabel.Text = "Progress (" + this.actualExperimentAmount + "/" + this.dataInput.ExperimentsAmount + ")";
            this.progressLabel.Text = "Progress (100%)";
            this.progressBar.Value = 100;
            this.startButton.Enabled = true;
            this.saveButton.Enabled = true;
            this.pauseButton.Text = "PAUSE";

            this.SetButtonsEnable(false);
        }

        private void DrawChart()
        {
            this.tabControl.TabPages[0].Enabled = false;
            this.tabControl.TabPages[1].Enabled = false;
            this.tabControl.TabPages[2].Enabled = false;

            this.inverseFunctionChart.Series[0].Points.Clear();
            this.inverseFunctionChart.Series[1].Points.Clear();

            this.neymanChart.Series[0].Points.Clear();
            this.neymanChart.Series[1].Points.Clear();

            this.metropolisChart.Series[0].Points.Clear();
            this.metropolisChart.Series[1].Points.Clear();

            if (this.inverseCheckBox.Checked)
            {
                this.tabControl.TabPages[0].Enabled = true;

                this.inverseFunctionChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.inverseFunctionChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.inverseFunctionChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.inverseFunctionChart.Series[1].Points.DataBindXY(this.experiment.InverseFunctionMethodObj.GetIntervalsList(), this.experiment.InverseFunctionMethodObj.GetResultList());
            }

            if (this.neymanCheckBox.Checked)
            {
                this.tabControl.TabPages[1].Enabled = true;

                this.neymanChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.neymanChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.neymanChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.neymanChart.Series[1].Points.DataBindXY(this.experiment.NeymanMethodObj.GetIntervalsList(), this.experiment.NeymanMethodObj.GetResultList());
            }

            if (this.metropolisCheckBox.Checked)
            {
                this.tabControl.TabPages[2].Enabled = true;

                this.metropolisChart.ChartAreas[0].AxisX.Minimum = this.experiment.DataInput.IntervalBegin;
                this.metropolisChart.ChartAreas[0].AxisX.Maximum = this.experiment.DataInput.IntervalEnd;

                this.metropolisChart.Series[0].Points.DataBindXY(this.experiment.AnalyticMethodObj.GetIntervalsList(), this.experiment.AnalyticMethodObj.GetResultList());
                this.metropolisChart.Series[1].Points.DataBindXY(this.experiment.MetropolisMethodObj.GetIntervalsList(), this.experiment.MetropolisMethodObj.GetResultList());
            }
        }

        private void SaveExperimentToDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3"))
            {
                connection.Open();

                byte[] serializedDataInput;
                byte[] serializedAnalyticMethod;
                byte[] serializedInverseMethod;
                byte[] serializedNeymanMethod;
                byte[] serializedMetropolisMethod;

                BinaryFormatter formatter = new BinaryFormatter();

                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, this.experiment.DataInput);
                    serializedDataInput = ms.ToArray();

                    formatter.Serialize(ms, this.experiment.AnalyticMethodObj);
                    serializedAnalyticMethod = ms.ToArray();

                    formatter.Serialize(ms, this.experiment.InverseFunctionMethodObj);
                    serializedInverseMethod = ms.ToArray();

                    formatter.Serialize(ms, this.experiment.NeymanMethodObj);
                    serializedNeymanMethod = ms.ToArray();

                    formatter.Serialize(ms, this.experiment.MetropolisMethodObj);
                    serializedMetropolisMethod = ms.ToArray();
                }

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    List<SQLiteParameter> parameterList = new List<SQLiteParameter>();

                    for (int i = 0; i < 5; i++)
                        parameterList.Add(new SQLiteParameter());

                    command.CommandText = "INSERT INTO experiment (id, input, analytic, inverse, neyman, metropolis) " +
                        "VALUES (null, @input, @analytic, @inverse, @neyman, @metropolis);";

                    parameterList[0] = new SQLiteParameter("input", serializedDataInput);
                    parameterList[1] = new SQLiteParameter("analytic", serializedAnalyticMethod);
                    parameterList[2] = new SQLiteParameter("inverse", serializedInverseMethod);
                    parameterList[3] = new SQLiteParameter("neyman", serializedNeymanMethod);
                    parameterList[4] = new SQLiteParameter("metropolis", serializedMetropolisMethod);

                    for (int i = 0; i < 5; i++)
                        command.Parameters.Add(parameterList[i]);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        ShowMessageBox("Experiment results were saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.isSaved = true;
                        this.mainForm.LoadExperimentsFromDB();
                    }
                    else
                        ShowMessageBox("Error while adding experiment to DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckInputs()
        {
            if (this.gammaTextBox.Text.Contains('.'))
                this.gammaTextBox.Text = this.gammaTextBox.Text.Replace('.', ',');
            if (this.beginTextBox.Text.Contains('.'))
                this.beginTextBox.Text = this.beginTextBox.Text.Replace('.', ',');
            if (this.endTextBox.Text.Contains('.'))
                this.endTextBox.Text = this.endTextBox.Text.Replace('.', ',');

            if (this.experimentsTextBox.Text.Equals(String.Empty) ||
                 this.partitionsTextBox.Text.Equals(String.Empty) ||
                 this.gammaTextBox.Text.Equals(String.Empty) ||
                 this.beginTextBox.Text.Equals(String.Empty) ||
                 this.endTextBox.Text.Equals(String.Empty))
            {
                ShowMessageBox("Some fields are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(this.gammaTextBox.Text) <= 0)
            {
                ShowMessageBox("Scale parameter γ must be greater then 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (double.Parse(this.beginTextBox.Text) >= double.Parse(this.endTextBox.Text))
            {
                ShowMessageBox("Interval end must be greater then interval begin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!this.inverseCheckBox.Checked && !this.neymanCheckBox.Checked && !this.metropolisCheckBox.Checked)
            {
                ShowMessageBox("At least one method must be chosen!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.metropolisCheckBox.Checked && double.Parse(this.endTextBox.Text) + double.Parse(this.beginTextBox.Text) != 0)
            {
                ShowMessageBox("For correct work of Metropolis method middle of the interval (x0) should be at 0! Example: [-5; 5]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GetInputs()
        {
            int experiments = int.Parse(this.experimentsTextBox.Text);
            int partitions = int.Parse(this.partitionsTextBox.Text);
            double gamma = double.Parse(this.gammaTextBox.Text);
            int begin = int.Parse(this.beginTextBox.Text);
            int end = int.Parse(this.endTextBox.Text);
            bool isInverseFunctionChecked = this.inverseCheckBox.Checked;
            bool isNeymanChecked = this.neymanCheckBox.Checked;
            bool isMetropolisChecked = this.metropolisCheckBox.Checked;

            this.dataInput = new DataInput(experiments, partitions, gamma, begin, end, isInverseFunctionChecked, isNeymanChecked, isMetropolisChecked);
        }

        private void ExperimentsTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(this.experimentsTextBox.Text, out value))
            {
                if (value <= 0)
                    this.experimentsTextBox.Text = String.Empty;
            }
            else
            {
                this.experimentsTextBox.Text = String.Empty;
            }
        }

        private void PartitionsTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(this.partitionsTextBox.Text, out value))
            {
                if (value <= 0)
                    this.partitionsTextBox.Text = String.Empty;
            }
            else
                this.partitionsTextBox.Text = String.Empty;
        }

        private void GammaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.CheckInput(sender))
                this.gammaTextBox.Text = String.Empty;
        }

        private void BeginTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (this.beginTextBox.Text.Equals("-"))
                return;

            if (!int.TryParse(this.beginTextBox.Text, out value))
                this.beginTextBox.Text = String.Empty;
        }

        private void EndTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (this.endTextBox.Text.Equals("-"))
                return;

            if (!int.TryParse(this.endTextBox.Text, out value))
                this.endTextBox.Text = String.Empty;
        }

        private bool CheckInput(object sender)
        {
            double value;

            TextBox input = (TextBox)sender;
            String text = input.Text;

            if (text.Equals("-"))
                return true;

            if (text.Contains('.'))
                text = text.Replace('.', ',');

            if (Double.TryParse(text, out value))
                return true;
            else
                return false;
        }

        private void AddNewExperimentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isSaved && this.experiment != null)
            {
                DialogResult result = ShowMessageBox("Do you want to save current experiment results?", "Exit without saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveExperimentToDB();
                    return;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        private DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
        #endregion
    }
} 
        
