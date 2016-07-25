using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CourseProject
{
    [Serializable]
    public abstract class Method : IDisposable
    {
        #region Private fields
        private BackgroundWorker worker;

        private bool isWorkFinished;
        private bool disposed;

        private List<double> resultList;
        private List<double> intervalsList;
        private List<double> analyticResultList;
        private List<double> analyticIntervalsList;
        #endregion

        #region Private methods
        private void InitializeBackgroundWorker()
        {
            this.worker = new BackgroundWorker();

            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;

            this.worker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            this.worker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        } 
        #endregion

        #region Protected fields
        protected Random random;

        protected int experimentsAmount;
        protected int partitionsAmount;
        protected double gamma;
        protected double intervalBegin;
        protected double intervalEnd;
        protected double intervalDelta;
        protected double x0;
        protected double leftZone;
        protected double rightZone;
        #endregion

        #region Constructor
        public Method(DataInput dataInput)
        {
            this.InitializeBackgroundWorker();

            this.random = new Random();

            this.isWorkFinished = false;
            this.disposed = false;

            this.resultList = new List<double>(new double[dataInput.PartitionsAmount]);
            this.intervalsList = new List<double>();
            this.analyticResultList = new List<double>();
            this.analyticIntervalsList = new List<double>();

            this.experimentsAmount = dataInput.ExperimentsAmount;
            this.partitionsAmount = dataInput.PartitionsAmount;
            this.gamma = dataInput.Gamma;
            this.x0 = dataInput.X0;
            this.intervalBegin = dataInput.IntervalBegin;
            this.intervalEnd = dataInput.IntervalEnd;

            this.intervalDelta = (this.intervalEnd - this.intervalBegin) / (double)this.partitionsAmount;
            this.leftZone = this.intervalBegin;
            this.rightZone = this.intervalBegin + this.intervalDelta;

            double delta = (this.intervalEnd - this.intervalBegin) / 1000.0;

            for (double i = this.intervalBegin; i < this.intervalEnd; i += delta)
            {
                this.analyticIntervalsList.Add(i);
                this.analyticResultList.Add(this.GetPDF(i));
            }
        }
        #endregion

        #region Protected methods
        protected abstract void ExecuteMethod();

        protected void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < this.experimentsAmount; i++)
            {
                if (this.worker.CancellationPending)
                    break;

                this.ExecuteMethod();
            }
        }

        protected void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        protected void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                System.Windows.Forms.MessageBox.Show("BackgroundWorker was cancelled!");
            }
            else if (!(e.Error == null))
            {
                System.Windows.Forms.MessageBox.Show("Error occured during backgroundworker's execution!");
            }
            else
            {
                this.FillIntervalsList();
                this.isWorkFinished = true;
            } 
        }

        protected void InsertNewValue(double value)
        {
            for (int i = 0; i < this.partitionsAmount; i++)
            {
                if (value > this.leftZone && value <= this.rightZone)
                {
                    this.resultList[i]++;
                    break;
                }

                this.leftZone += this.intervalDelta;
                this.rightZone += this.intervalDelta;
            }

            this.leftZone = this.intervalBegin;
            this.rightZone = this.intervalBegin + this.intervalDelta;
        }

        protected double GetPDF(double value)
        {
            return 1 / (Math.PI * this.gamma * (1 + Math.Pow((value - this.x0) / this.gamma, 2)));
        } 

        protected void PrepareResultList() {
            double max = this.resultList.Max();
            double maxAnalytic = this.analyticResultList.Max();

            for (int i = 0; i < this.resultList.Count; i++)
                this.resultList[i] = (this.resultList[i] / max) * maxAnalytic;
        }

        protected void FillIntervalsList()
        {
            for (double i = this.intervalBegin; i < this.intervalEnd; i += this.intervalDelta)
            {
                this.IntervalsList.Add(i);
            }

            if (this.ResultList.Count != this.IntervalsList.Count)
                this.IntervalsList.RemoveAt(this.IntervalsList.Count - 1);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.worker.Dispose();
            }

            this.disposed = true;
        }
        #endregion

        #region Public properties
        public bool IsWorkFinished
        {
            get
            {
                return this.isWorkFinished;
            }
        }
        public List<double> ResultList
        {
            get
            {
                this.PrepareResultList();
                return this.resultList;
            }
        }

        public List<double> IntervalsList
        {
            get
            {
                return this.intervalsList;
            }
        }

        public IEnumerable<double> AnalyticResultList
        {
            get
            {
                return this.analyticResultList;
            }
        }

        public IEnumerable<double> AnalyticIntervalsList
        {
            get
            {
                return this.analyticIntervalsList;
            }
        }
        #endregion

        #region Public methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RunBackgroundWorker()
        {
            this.worker.RunWorkerAsync();
        }
        #endregion
    }
}
