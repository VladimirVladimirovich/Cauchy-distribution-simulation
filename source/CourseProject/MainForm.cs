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
    public partial class MainForm : Form
    {
        private DataInput dataInput;
        private AnalyticMethod analyticMethod;
        private InverseFunctionMethod inverseFunctionMethod;
        private NeymanMethod neymanMethod;
        private MetropolisMethod metropolisMethod;
        private List<Experiment> experimentsList;
        private List<int> idList = new List<int>();

        public MainForm()
        {
            InitializeComponent();

            loadExperimentsFromDB();
        }

        public void loadExperimentsFromDB() 
        {
            idList.Clear();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM experiment;";

                SQLiteDataReader reader = command.ExecuteReader();
                BinaryFormatter formatter = new BinaryFormatter();
          
                experimentsList = new List<Experiment>();

                while (reader.Read())
                {
                    using (MemoryStream ms = new MemoryStream((byte[])reader["metropolis"]))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        dataInput = new DataInput((DataInput)formatter.Deserialize(ms));
                        analyticMethod = new AnalyticMethod((AnalyticMethod)formatter.Deserialize(ms));
                        inverseFunctionMethod = new InverseFunctionMethod((InverseFunctionMethod)formatter.Deserialize(ms));
                        neymanMethod = new NeymanMethod((NeymanMethod)formatter.Deserialize(ms));
                        metropolisMethod = new MetropolisMethod((MetropolisMethod)formatter.Deserialize(ms));

                        idList.Add(int.Parse(reader["id"].ToString()));
                        experimentsList.Add(new Experiment(dataInput, analyticMethod, inverseFunctionMethod, neymanMethod, metropolisMethod));
                    }
                }

                reader.Close();
            }

            fillListBox();
        }

        private void fillListBox()
        {
            listBox.Items.Clear();

            for (int i = 0; i < experimentsList.Count; i++)
            {
                String text = (i + 1) + ") Experiments = " + experimentsList[i].dataInput.actualExperimentsAmount + ", partitions = " +
                    experimentsList[i].dataInput.partitionsAmount + ", y = " + experimentsList[i].dataInput.gamma +
                    ", [" + experimentsList[i].dataInput.intervalBegin + ";" + experimentsList[i].dataInput.intervalEnd +
                    "]" + (experimentsList[i].dataInput.isInverseFunctionChecked ? ", Inverse function" : "") +
                    (experimentsList[i].dataInput.isNeymanChecked ? ", Neumann" : "") +
                    (experimentsList[i].dataInput.isMetropolisChecked ? ", Metropolis" : "");

                listBox.Items.Add(text);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewExperimentForm form = new AddNewExperimentForm(this);
            form.Show();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                ShowExperimentForm form = new ShowExperimentForm(experimentsList[listBox.SelectedIndex]);
                form.Show();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
                return;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM experiment WHERE id = @id;";

                command.Parameters.Add(new SQLiteParameter("id", idList[listBox.SelectedIndex]));

                if (command.ExecuteNonQuery() == 1)
                {
                    loadExperimentsFromDB();
                    return;
                }
                else
                    MessageBox.Show("Error while deleting experiment!");
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowExperimentForm form = new ShowExperimentForm(experimentsList[listBox.SelectedIndex]);
                form.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cauchyDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CauchyInfoForm form = new CauchyInfoForm();
            form.Show();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeveloperInfoForm form = new DeveloperInfoForm();
            form.Show();
        }

    }
}
