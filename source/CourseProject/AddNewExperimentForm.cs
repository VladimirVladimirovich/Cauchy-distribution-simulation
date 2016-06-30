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
        public MainForm mainForm;

        public static Random random;

        public DataInput dataInput;
        public AnalyticMethod analyticObj;
        public InverseFunctionMethod inverseMethodObj;
        public NeymanMethod neymanMethodObj;
        public MetropolisMethod metropolisMethodObj;
        public Experiment experiment;

        int actualExperimentAmount;
        bool pause;
        bool isSaved;

        public AddNewExperimentForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (checkInputs())
                getInputs();
            else
                return;

            random = new Random();
            analyticObj = new AnalyticMethod(dataInput.gamma, dataInput.intervalBegin, dataInput.intervalEnd, dataInput.x0);
            inverseMethodObj = new InverseFunctionMethod(dataInput.experimentsAmount, dataInput.partitionsAmount, dataInput.gamma, dataInput.intervalBegin, dataInput.intervalEnd, dataInput.x0);
            neymanMethodObj = new NeymanMethod(dataInput.experimentsAmount, dataInput.partitionsAmount, dataInput.gamma, dataInput.intervalBegin, dataInput.intervalEnd, dataInput.x0);
            metropolisMethodObj = new MetropolisMethod(dataInput.experimentsAmount, dataInput.partitionsAmount, dataInput.gamma, dataInput.intervalBegin, dataInput.intervalEnd, dataInput.x0);
            experiment = new Experiment(dataInput, analyticObj, inverseMethodObj, neymanMethodObj, metropolisMethodObj);

            actualExperimentAmount = 0;
            pause = false;
            isSaved = false;

            setButtonsEnable(true);
            startButton.Enabled = false;
            saveButton.Enabled = false;

            backgroundWorker.RunWorkerAsync();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                return;

            if (!pause)
            {
                pause = true;
                pauseButton.Text = "CONTINUE";
            }
            else
            {
                pause = false;
                pauseButton.Text = "PAUSE";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy || pause)
            {
                backgroundWorker.CancelAsync();
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            saveExperimentToDB();
        }

        private void setButtonsEnable(bool status)
        {
            stopButton.Enabled = status;
            pauseButton.Enabled = status;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int step = dataInput.experimentsAmount / 100;

            for (int i = 0; i < dataInput.experimentsAmount; i++)
            {
                if (backgroundWorker.CancellationPending)
                    break;

                if(inverseCheckBox.Checked)
                    experiment.executeInverseMethod(random);
                if(neymanCheckBox.Checked)
                    experiment.executeNeymanMethod(i, random);
                if(metropolisCheckBox.Checked)
                    experiment.executeMetropolisMethod(random);

                if(i % step == 0)
                    ((BackgroundWorker)sender).ReportProgress((i * 100) / experiment.dataInput.experimentsAmount, actualExperimentAmount);

                actualExperimentAmount++;

                if (pause)
                {
                    ((BackgroundWorker)sender).ReportProgress((i * 100) / experiment.dataInput.experimentsAmount, actualExperimentAmount);

                    while (pause)
                        if (backgroundWorker.CancellationPending)
                        {
                            pause = false;
                            return;
                        }
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = "Progress (" + e.ProgressPercentage.ToString() + "%)";
            progressBar.Value = e.ProgressPercentage;
            actualProgressLabel.Text = "Progress (" + (int)e.UserState + "/" + dataInput.experimentsAmount + ")";

            //if (e.UserState != null) 
               // if(e.UserState.ToString().Equals("Draw"))
                   // drawChart();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            experiment.dataInput.actualExperimentsAmount = this.actualExperimentAmount;
            experiment.fillIntervalsList();
            drawChart();

            actualProgressLabel.Text = "Progress (" + actualExperimentAmount + "/" + dataInput.experimentsAmount + ")";
            progressLabel.Text = "Progress (100%)";
            progressBar.Value = 100;
            startButton.Enabled = true;
            saveButton.Enabled = true;
            pauseButton.Text = "PAUSE";
            setButtonsEnable(false);
        }

        private void drawChart() 
        {
            tabControl.TabPages[0].Enabled = false;
            tabControl.TabPages[1].Enabled = false;
            tabControl.TabPages[2].Enabled = false;

            inverseFunctionChart.Series[0].Points.Clear();
            inverseFunctionChart.Series[1].Points.Clear();

            neymanChart.Series[0].Points.Clear();
            neymanChart.Series[1].Points.Clear();

            metropolisChart.Series[0].Points.Clear();
            metropolisChart.Series[1].Points.Clear();

            if (inverseCheckBox.Checked) 
            {
                tabControl.TabPages[0].Enabled = true;

                inverseFunctionChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                inverseFunctionChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                inverseFunctionChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                inverseFunctionChart.Series[1].Points.DataBindXY(experiment.inverseFunctionMethodObj.getIntervalsList(), experiment.inverseFunctionMethodObj.getResultList());
            }

            if (neymanCheckBox.Checked)
            {
                tabControl.TabPages[1].Enabled = true;

                neymanChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                neymanChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                neymanChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                neymanChart.Series[1].Points.DataBindXY(experiment.neymanMethodObj.getIntervalsList(), experiment.neymanMethodObj.getResultList());
            }

            if (metropolisCheckBox.Checked)
            {
                tabControl.TabPages[2].Enabled = true;

                metropolisChart.ChartAreas[0].AxisX.Minimum = experiment.dataInput.intervalBegin;
                metropolisChart.ChartAreas[0].AxisX.Maximum = experiment.dataInput.intervalEnd;

                metropolisChart.Series[0].Points.DataBindXY(experiment.analyticMethodObj.getIntervalsList(), experiment.analyticMethodObj.getResultList());
                metropolisChart.Series[1].Points.DataBindXY(experiment.metropolisMethodObj.getIntervalsList(), experiment.metropolisMethodObj.getResultList());
            }            
        }

        private void saveExperimentToDB()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3");
            connection.Open();

            byte[] serializedDataInput;
            byte[] serializedAnalyticMethod;
            byte[] serializedInverseMethod;
            byte[] serializedNeymanMethod;
            byte[] serializedMetropolisMethod;

            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, experiment.dataInput);
                serializedDataInput = ms.ToArray();

                formatter.Serialize(ms, experiment.analyticMethodObj);
                serializedAnalyticMethod = ms.ToArray();

                formatter.Serialize(ms, experiment.inverseFunctionMethodObj);
                serializedInverseMethod = ms.ToArray();

                formatter.Serialize(ms, experiment.neymanMethodObj);
                serializedNeymanMethod = ms.ToArray();

                formatter.Serialize(ms, experiment.metropolisMethodObj);
                serializedMetropolisMethod = ms.ToArray();
            }

            SQLiteCommand command = connection.CreateCommand();
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
                MessageBox.Show("Experiment results were saved successfully!");
                isSaved = true;
                mainForm.loadExperimentsFromDB();
            }
            else
                MessageBox.Show("Error while adding experiment to DB!");
        }

        private bool checkInputs()
        {
            if (gammaTextBox.Text.Contains('.'))
                gammaTextBox.Text = gammaTextBox.Text.Replace('.', ',');
            if (beginTextBox.Text.Contains('.'))
                beginTextBox.Text = beginTextBox.Text.Replace('.', ',');
            if (endTextBox.Text.Contains('.'))
                endTextBox.Text = endTextBox.Text.Replace('.', ',');

            if (experimentsTextBox.Text.Equals(String.Empty) ||
                partitionsTextBox.Text.Equals(String.Empty) ||
                gammaTextBox.Text.Equals(String.Empty) ||
                beginTextBox.Text.Equals(String.Empty) ||
                endTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Some fields are empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(double.Parse(gammaTextBox.Text) <= 0) 
            {
                MessageBox.Show("Scale parameter γ must be greater then 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(double.Parse(beginTextBox.Text) >= double.Parse(endTextBox.Text)) 
            {
                MessageBox.Show("Interval end must be greater then interval begin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!inverseCheckBox.Checked && !neymanCheckBox.Checked && !metropolisCheckBox.Checked) 
            {
                MessageBox.Show("At least one method must be chosen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (metropolisCheckBox.Checked && double.Parse(endTextBox.Text) + double.Parse(beginTextBox.Text) != 0)
            {
                MessageBox.Show("For correct work of Metropolis method middle of the interval (x0) should be at 0! Example: [-5; 5]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void getInputs()
        {
            int experiments = int.Parse(experimentsTextBox.Text);
            int partitions = int.Parse(partitionsTextBox.Text);
            double gamma = double.Parse(gammaTextBox.Text);
            int begin = int.Parse(beginTextBox.Text);
            int end = int.Parse(endTextBox.Text);
            bool isInverseFunctionChecked = inverseCheckBox.Checked;
            bool isNeymanChecked = neymanCheckBox.Checked;
            bool isMetropolisChecked = metropolisCheckBox.Checked;

            dataInput = new DataInput(experiments, partitions, gamma, begin, end, isInverseFunctionChecked, isNeymanChecked, isMetropolisChecked);
        }

        private void experimentsTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(experimentsTextBox.Text, out value))
            {
                if (value <= 0)
                    experimentsTextBox.Text = String.Empty;
            }
            else
                experimentsTextBox.Text = String.Empty;
        }

        private void partitionsTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(partitionsTextBox.Text, out value))
            {
                if (value <= 0)
                    partitionsTextBox.Text = String.Empty;
            }
            else
                partitionsTextBox.Text = String.Empty;
        }

        private void gammaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!checkInput(sender))
                gammaTextBox.Text = String.Empty;
        }

        private void beginTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (beginTextBox.Text.Equals("-"))
                return;

            if (!int.TryParse(beginTextBox.Text, out value))
                beginTextBox.Text = String.Empty;
        }

        private void endTextBox_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (endTextBox.Text.Equals("-"))
                return;

            if (!int.TryParse(endTextBox.Text, out value))
                endTextBox.Text = String.Empty;
        }

        private bool checkInput(object sender)
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
            if (!isSaved && experiment != null) 
            {
                DialogResult result = MessageBox.Show("Do you want to save current experiment results?", "Exit without saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) 
                {
                    saveExperimentToDB();
                    return;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

    }
}
