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
        #region PrivateFields
            private DataInput dataInput;
            private AnalyticMethod analyticMethod;
            private InverseFunctionMethod inverseFunctionMethod;
            private NeymanMethod neymanMethod;
            private MetropolisMethod metropolisMethod;
            private List<Experiment> experimentsList;
            private List<int> idList = new List<int>(); 
        #endregion

        #region Contructors
            public MainForm()
            {
                InitializeComponent();

                this.loadExperimentsFromDB();
            } 
        #endregion

        #region PublicMethods
            public void loadExperimentsFromDB()
            {
                this.idList.Clear();

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM experiment;";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            this.experimentsList = new List<Experiment>();

                            while (reader.Read())
                            {
                                using (MemoryStream ms = new MemoryStream((byte[])reader["metropolis"]))
                                {
                                    ms.Seek(0, SeekOrigin.Begin);
                                    this.dataInput = new DataInput((DataInput)formatter.Deserialize(ms));
                                    this.analyticMethod = new AnalyticMethod((AnalyticMethod)formatter.Deserialize(ms));
                                    this.inverseFunctionMethod = new InverseFunctionMethod((InverseFunctionMethod)formatter.Deserialize(ms));
                                    this.neymanMethod = new NeymanMethod((NeymanMethod)formatter.Deserialize(ms));
                                    this.metropolisMethod = new MetropolisMethod((MetropolisMethod)formatter.Deserialize(ms));

                                    this.idList.Add(int.Parse(reader["id"].ToString()));
                                    this.experimentsList.Add(new Experiment(dataInput, analyticMethod, inverseFunctionMethod, neymanMethod, metropolisMethod));
                                }
                            }

                            reader.Close();
                        }
                    }
                }

                this.fillListBox();
            }
            
        #endregion

        #region PrivateMethods
            private void fillListBox()
            {
                this.listBox.Items.Clear();

                for (int i = 0; i < this.experimentsList.Count; i++)
                {
                    String text = (i + 1) + ") Experiments = " + this.experimentsList[i].dataInput.actualExperimentsAmount + ", partitions = " +
                        this.experimentsList[i].dataInput.partitionsAmount + ", y = " + this.experimentsList[i].dataInput.gamma +
                        ", [" + this.experimentsList[i].dataInput.intervalBegin + ";" + this.experimentsList[i].dataInput.intervalEnd +
                        "]" + (this.experimentsList[i].dataInput.isInverseFunctionChecked ? ", Inverse function" : "") +
                        (this.experimentsList[i].dataInput.isNeymanChecked ? ", Neumann" : "") +
                        (this.experimentsList[i].dataInput.isMetropolisChecked ? ", Metropolis" : "");

                    this.listBox.Items.Add(text);
                }
            }

            private void addButton_Click(object sender, EventArgs e)
            {
                AddNewExperimentForm form = new AddNewExperimentForm(this);
                form.Show();
            }

            private void showButton_Click(object sender, EventArgs e)
            {
                if (this.listBox.SelectedItem != null)
                {
                    ShowExperimentForm form = new ShowExperimentForm(this.experimentsList[this.listBox.SelectedIndex]);
                    form.Show();
                }
            }

            private void deleteButton_Click(object sender, EventArgs e)
            {
                if (this.listBox.SelectedItem == null)
                    return;

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=Experiments.sqlite3"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM experiment WHERE id = @id;";
                        command.Parameters.Add(new SQLiteParameter("id", this.idList[this.listBox.SelectedIndex]));

                        if (command.ExecuteNonQuery() == 1)
                        {
                            this.loadExperimentsFromDB();
                            return;
                        }
                        else
                            MessageBox.Show("Error while deleting experiment!");
                    }
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
        #endregion
    }
}
