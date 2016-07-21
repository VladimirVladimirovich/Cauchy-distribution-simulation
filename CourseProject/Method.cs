using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class Method
    {
        #region Protected fields
        protected int experimentsAmount;
        protected int partitionsAmount;
        protected double gamma;
        protected double intervalBegin;
        protected double intervalEnd;
        protected double intervalDelta;
        protected double leftZone;
        protected double rightZone;
        protected double x0;
        protected Random random;
        #endregion

        #region Private fields
        private List<double> resultList;
        private List<double> intervalsList;
        private List<double> analyticResultList;
        private List<double> analyticIntervalsList; 
        #endregion

        #region Public properties
        public List<double> ResultList
        {
            get
            {
                double max = this.resultList.Max();
                AnalyticMethod analytic = new AnalyticMethod(this.gamma, this.intervalBegin, this.intervalEnd, this.x0);
                double maxAnalytic = analytic.GetResultList().Max();

                for (int i = 0; i < this.resultList.Count; i++)
                    this.resultList[i] = (this.resultList[i] / max) * maxAnalytic;

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

        public List<double> AnalyticResultList
        {
            get
            {
                return this.analyticResultList;
            }
        }

        public List<double> AnalyticIntervalsList
        {
            get
            {
                return this.analyticIntervalsList;
            }
        } 
        #endregion

        #region Public methods
        public Method(int experimentsAmount, int partitionsAmount, double gamma, double intervalBegin, double intervalEnd, double x0) 
        {
            this.experimentsAmount = experimentsAmount;
            this.partitionsAmount = partitionsAmount;
            this.gamma = gamma;
            this.intervalBegin = intervalBegin;
            this.intervalEnd = intervalEnd;
            this.x0 = x0;
            this.intervalDelta = (this.intervalEnd - this.intervalBegin) / (double)this.partitionsAmount;
            this.leftZone = this.intervalBegin;
            this.rightZone = this.intervalBegin + this.intervalDelta;

            this.resultList = new List<double>(this.partitionsAmount);
            this.intervalsList = new List<double>();
            this.analyticResultList = new List<double>();
            this.analyticIntervalsList = new List<double>();

            double delta = (this.intervalEnd - this.intervalBegin) / 1000.0;

            for (double i = this.intervalBegin; i < this.intervalEnd; i += delta)
            {
                this.analyticIntervalsList.Add(i);
                this.analyticResultList.Add(this.GetPDF(i));
            }
        }

        public virtual void ExecuteMethod()
        {

        }

        public void InsertNewValue(double value)
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

        /*public virtual List<double> GetResultList()
        {
            double max = this.resultList.Max();
            AnalyticMethod analytic = new AnalyticMethod(this.gamma, this.intervalBegin, this.intervalEnd, this.x0);
            double maxAnalytic = analytic.GetResultList().Max();

            for (int i = 0; i < this.resultList.Count; i++)
                this.resultList[i] = (this.resultList[i] / max) * maxAnalytic;

            return this.resultList;
        }

        public virtual List<double> GetIntervalsList() 
        { 
            return this.intervalsList; 
        }

        public List<double> GetAnalyticResultList() 
        { 
            return this.analyticResultList;
        }
        public List<double> GetAnalyticIntervalsList() 
        { 
            return this.analyticIntervalsList; 
        }*/

        public double GetPDF(double value)
        {
            return 1 / (Math.PI * this.gamma * (1 + Math.Pow((value - this.x0) / this.gamma, 2)));
        }
        #endregion
    }
}
